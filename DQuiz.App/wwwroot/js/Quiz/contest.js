$(function () {
    var rnd1 = Math.floor((Math.random() * 10) + 1);
    var rnd2 = Math.floor((Math.random() * 10) + 1);

    $('#randoms').html("Cevabı işaretleyebilmek için çözün: " + rnd1 + "+" + rnd2 + "= ?");

    
    var interval = window.setInterval(function () {
        

        $.ajax({
            type: "GET",
            url: '/Home/GetTimeDifference',
            success: function (received) {

                //var serverDate = moment(received.serverDate);
                //var momentnow = moment().tz('Europe/Istanbul').format("MM.D.yyyy HH:mm:ss");
                //var momentnow = moment(moment(), "MM.D.yyyy HH: mm: ss").tz('Europe/Istanbul');
                //seconds = serverDate.diff(momentnow, 'seconds');

                seconds = received.seconds;
                

                $('#timer').html(seconds);
                if (seconds == 1) {
                    clearInterval(interval);
                }

                window.setTimeout(function () {
                    window.location.href = '/sonuclar';
                }, seconds * 1000);
            },
            error: function (error) {

                console.log("Hata! " + error);
            },
            //dataType: 'json',
            //contentType: "application/json; charset=utf-8"
        });

        
    }, 1000);
    

    $("label.btn").on('click', function (event) {
        if ($('input[name=AnswerID]').is(':enabled')) {
            var selectedChoiceBtn = $(this).find('input:radio');

            var choice = selectedChoiceBtn.val();
            var questionid = $('#questionid').val();
            var questionmetricid = $('#questionmetricid').val();
            var captchasum = $('#captchasum').val();

            $.ajax({
                type: "POST",
                url: '/Home/Contest',
                data: { answerid: choice, questionid: questionid, questionmetricid: questionmetricid, random1: rnd1, random2: rnd2, sumcaptcha: captchasum },
                success: function (received) {
                    if (received.isSuccess === "False") {
                        $("#captchasum").css({
                            "border": "1px solid red"
                        });
                    }
                    else {
                        $('input[name=AnswerID]').attr("disabled", true);

                        $('label.btn').removeClass('lblbtnhover');

                        $('label.btn').removeClass('btn-primary').addClass('btn-secondary');
                        selectedChoiceBtn.parent().removeClass('btn-secondary').addClass('btn-success');
                    }
                },
                error: function (error) {
                    alert("Hata! Lütfen sayfayı tekrar yenileyin!");
                },
                dataType: 'json'
            });
        }
    });

    var hubConn = new signalR.HubConnectionBuilder()
        .withUrl("/poolhub")
        .build();
    hubConn.on('updatecounter',
        function (data) {
            $('#timer').html(data);
        });
    hubConn.on('endcountdown',
        function (data) {
            window.location.href = '/sonuclar';
        });
    hubConn.start();
});
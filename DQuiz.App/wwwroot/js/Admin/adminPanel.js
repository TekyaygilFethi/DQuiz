$(function () {
        $('#submit').click(function () {
            var question = $('#question').val();
            var answer1 = $('#answer1').val();
            var answer2 = $('#answer2').val();
            var answer3 = $('#answer3').val();
            var answer4 = $('#answer4').val();

            var selected = $("input[name='answerCheck']:checked").data("id");

            $.ajax({
                type: "POST",
                url: '/Admin/AddQuestion',
                data: { question: question, answer1: answer1, answer2: answer2, answer3: answer3, answer4: answer4, trueanswer: selected },
                success: function (received) {
                    alert("Soru başarıyla oluşturuldu!");
                    $('#question').val("");
                    $('#answer1').val("");
                    $('#answer2').val("");
                    $('#answer3').val("");
                    $('#answer4').val("");
                },
                error: function (error) {

                    alert("Hata! " + error);
                },
                dataType: 'json'
            });

        });
    });
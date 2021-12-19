document.addEventListener('DOMContentLoaded', function () {

    var valuesGlobal = [0, 0];


    $.ajax({
        type: "GET",
        url: '/Home/GetTotalSumJson',
        success: function (result) {
            valuesGlobal = [result.data.totalTrue, result.data.totalFalse];

            var globalChart = new Chart(document.getElementById("serviceGlobalChart"),
                {
                    type: 'pie',
                    data: {
                        labels: ["Doğru Cevap", "Yanlış Cevap"],
                        datasets: [{
                            label: "Doğruluk Oranları",
                            backgroundColor: ["#3e95cd", "#8e5ea2"],
                            data: valuesGlobal
                        }]
                    },
                    options: {
                        responsive: false,
                        title: {
                            display: true,
                            text: 'Hub Quiz'
                        }
                    }
                });

        },
        error: function (error) {
            alert("Hata! " + error);
        },
    });
});
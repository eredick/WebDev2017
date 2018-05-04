var rowTotal = 25
function init() {
    $.get('/Customer/Count/' + rowTotal, function (data) {
        var paginas = data;
        $(".pagination").bootpag({
            total: paginas,
            page: 1,
            maxVisible: 5
        }).on('page', function (event, num) {
            getCustomers(num);
        });
        getCustomers(1);
    });
}

function getCustomers(num) {
    var url = "/Customer/List/" + num + "/" + rowTotal;
    $.get(url, function (data) {
        $(".content").html(data);
    });
}
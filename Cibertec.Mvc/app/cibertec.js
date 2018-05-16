var ids = [];
var connectionId = "";

function getModalContent(url, title, id) {
    $.get(url, function (data) {
        $(".modal-body").html(data);
        $(".modal-title").html(title);
    });

    var hub = $.connection.userHub;
    hub.server.addUserId(id);
}

function removeUserId(id) {
    var hub = $.connection.userHub;
    hub.server.removeUserId(id);
}

function configurarMensajeEnUso(id) {
    var item = $.grep(ids, function (obj) {
        return obj.ConnectionId === connectionId && obj.Id === id;
    })[0];
    if (item && item.MostrarMensaje) {
        $('#userEditAlert').removeClass('hidden');
    } else {
        $('#userEditAlert').addClass('hidden');        
    }
}

function success(data) {
    closeModal(data.option);
}

function closeModal(option) {
    $("button[data-dismiss='modal']").click();
    $(".modal-body").html("");
    $(".modal-title").html("");
    alertConfig(option);
}

function alertConfig(option) {
    $('#insertAlert').addClass("hidden");
    $('#editAlert').addClass("hidden");
    $('#deleteAlert').addClass("hidden");

    switch (option) {
        case "create":
            $('#insertAlert').removeClass("hidden");
            break;
        case "edit":
            $('#editAlert').removeClass("hidden");
            break;
        case "delete":
            $('#deleteAlert').removeClass("hidden");
            break;
        default:
    }
}

function getModalContent(url, title) {
    $.get(url, function (data) {
        $(".modal-body").html(data);
        $(".modal-title").html(title);
    });
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
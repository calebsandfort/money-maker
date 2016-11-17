var Site;
if (!Site) {
    Site = {
        RootUrl: ""
    };
}

$().ready(function () {
    Site.RootUrl = $("#uxInput_RootUrl").val();

    $("body").on("click", ".matchupLink", Site.matchupLinkClick);
});

Site.matchupLinkClick = function () {
    var matchupModal = $("#matchupModal");
    
    $.ajax({
        dataType: "html",
        type: "GET",
        url: Site.RootUrl + 'Home/MatchupModalContent',
        data: {
            id: $(this).data("id")
        },
        success: function (result) {
            matchupModal.find(".modal-body").html(result);
            matchupModal.modal("show");
        }
    });
}
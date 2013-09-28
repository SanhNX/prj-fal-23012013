$(document).ready(function () {
    $('.lnkSelect').on('click', function (e) {

        var href = $(this).attr('id');
        parent.popupRetVal = href;
        parent.$.fancybox.close();
        // removeTR(indexRow);
        // indexSTT = indexSTT - 1;
    });
});
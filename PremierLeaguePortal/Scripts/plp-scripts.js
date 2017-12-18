$(document).ready(function () {
    tinymce.init({
        selector: "#blogTA",
        entity_encoding: "raw",
        oninit: "setPlainText",
        plugins: [
            'advlist autolink lists link image charmap preview hr anchor pagebreak',
            'searchreplace wordcount visualblocks visualchars  fullscreen',
            'insertdatetime media nonbreaking save table contextmenu directionality',
        ],
        toolbar1: 'undo redo | insert | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
        image_advtab: true
    });
});


function disableButton() {
    $('button').prop('disabled', true);
}

$(function () {
    $("#plp-add-item").click(function () {
        //alert("Handler for .click() called.");
        var itemListEl = $("#plp-pool-item-list");
        debugger;
        var lastItemIndex = parseInt(itemListEl.find("input").last().attr('id').match(/\d+/)[0]);
        var currentItemIndex = lastItemIndex + 1;
        var newLabelForItem = $("<label>")
            .text("Label")
            .addClass("control-label col-md-2")
            .attr("for", "Items_" + currentItemIndex + "__Label");
        var newItem = $("<input>").addClass("form-control text-box single-line")
            .attr("id", "Items_" + currentItemIndex + "__Label").attr("name", "Items[" + currentItemIndex + "].Label");
        itemListEl.append(newLabelForItem);
        itemListEl.append(newItem);
    });
});
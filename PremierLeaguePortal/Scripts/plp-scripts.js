//Configure tinyMCE
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

//Add new PoolItem field
$(function () {
    $("#plp-add-item").click(function () {
        //alert("Handler for .click() called.");
        var itemListEl = $("#plp-pool-item-list");
        debugger;
        var lastItemIndex = parseInt(itemListEl.find("input.form-control").last().attr('id').match(/\d+/)[0]);
        var currentItemIndex = lastItemIndex + 1;
        var newLabelForItem = $("<label>")
            .text("Label")
            .addClass("control-label col-md-2")
            .attr("for", "Items_" + currentItemIndex + "__Label");
        var newItem = $("<input>").addClass("form-control text-box single-line")
            .attr("id", "Items_" + currentItemIndex + "__Label").attr("name", "Items[" + currentItemIndex + "].Label");
        var removeButton = $("<input>").attr("type", "button").attr("value", "remove " + currentItemIndex).addClass("plp-remove-item");
        removeButton.click(removePoolItem);
        itemListEl.append(newLabelForItem);
        itemListEl.append(newItem);
        itemListEl.append(removeButton);
    });
});

//remove specific PoolItem field
var removePoolItem = function (ev) {
    var indexToRemove = parseInt(ev.currentTarget.value.match(/\d+/)[0]);    
    $("label[for=Items_" + indexToRemove + "__Label]").remove();
    $("#" + "Items_" + indexToRemove + "__Label").remove();
    $(this).remove();
}

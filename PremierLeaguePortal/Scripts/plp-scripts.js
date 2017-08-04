//$(document).ready(function () {
//    console.log("ready!");
//    tinymce.init({
//        selector: 'textarea',
//        oninit: "setPlainText",
//        plugins: ["paste link"],
//        
//        //plugins: "link",
//        toolbar: "link",
//        default_link_target: "_blank"
//    });
//});

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
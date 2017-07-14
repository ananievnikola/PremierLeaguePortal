//$('form input[type=submit]').click(function () {
//    tinyMCE.triggerSave();
//});

$(document).ready(function () {
    console.log("ready!");
    tinymce.init({
        selector: 'textarea',
        oninit: "setPlainText",
        plugins: "paste"
    });
});


function disableButton() {
    $('button').prop('disabled', true);
}
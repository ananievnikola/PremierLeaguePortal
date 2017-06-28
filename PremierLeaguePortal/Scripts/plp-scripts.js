//$('#submitform').click(function () {
//    $.validator.setdefaults({
//        ignore: ''
//    });
//    tinymce.triggersave();
//});
$('form input[type=submit]').click(function () {
    alert('ss');
    tinyMCE.triggerSave();
});
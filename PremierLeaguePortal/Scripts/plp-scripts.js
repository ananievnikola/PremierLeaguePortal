$('form input[type=submit]').click(function () {
    tinyMCE.triggerSave();
});

function disableButton() {
    $('button').prop('disabled', true);
}
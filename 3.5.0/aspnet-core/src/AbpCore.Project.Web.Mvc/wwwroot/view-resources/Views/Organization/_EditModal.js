(function ($) {
    var _organizationAppService = abp.services.app.organization;
    var _$modal = $('#editMode');
    var _$form = $('form[name=editForm]');

    _organizationAppService.getAll({
        maxResultCount: 9999,
        skipCount: 0,
        sorting: 'code',
        order: 'desc'
    }).done(function (data) {
        $('#selectTree').selectTree({
            data: data.items
        });
    });
    function save() {
        if (!_$form.valid()) {
            return;
        }
        var organization = _$form.serializeFormToObject();
        abp.ui.setBusy(_$modal);
        _organizationAppService.update(organization).done(function () {
            _$modal.modal('hide');
            reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    }
    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });
    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });
    $.AdminBSB.input.activate(_$form);
    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);
$(function () {
    var $modal = $('#OrganizationCreateModal');
    var _organizationAppService = abp.services.app.organization;
    var $form = $modal.find('form');
    var $tree = $('#tree');
    _organizationAppService.getAll({
        maxResultCount: 9999,
        skipCount: 0,
        sorting: 'code',
        order: 'desc'
    }).done(function (data) {
        var dataStr = JSON.stringify(data.items);
        dataStr = dataStr.replace(/displayName/g, 'text');
        $tree.treeview({
            data: $.initTreeData(JSON.parse(dataStr))
        });
    });
    $('#btn-add').click(function () {
        var node = $tree.treeview('getSelected')[0];
        if (node) {
            $form.find('input[name="ParentId"]').val(node.id);
            $form.find('#ParentDisplayName').val(node.text);
        }
        $modal.modal('show');
    });
    $('#btn-del').click(function () {
        var node = $tree.treeview('getSelected')[0];
        if (!node) {
            abp.message.info(L("Please select the items to be deleted"), L("Delete"));
            return;
        }
        _organizationAppService.delete({ id: node.id }).done(function (data) { reload(); });
    });
    $('#btn-edit').click(function () {
        var node = $tree.treeview('getSelected')[0];
        if (!node) { abp.message.info(L("Please choose the edit item"), L("Edit")); return; }
        $.getModal({
            url: abp.appPath + 'Organization/EditModal?id=' + node.id,
            title: 'EditOrganizations',
            modelId: 'editMode',
        });
    });
    $form.find('button[type="submit"]').click(function (e) {
        e.preventDefault();
        if (!$form.valid()) {
            return;
        }
        var organization = $form.serializeFormToObject();
        abp.ui.setBusy($modal);
        _organizationAppService.create(organization).done(function () {
            $modal.modal('hide');
            reload();
        }).always(function () {
            abp.ui.clearBusy($modal);
        });
    });
    $form.validate();
});
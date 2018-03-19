(function () {
    $(function () {

        var _roleService = abp.services.app.role;
        var _$modal = $('#RoleCreateModal');
        var _$form = _$modal.find('form');
        var _$table = $('#table');

        var options = $.tableParameter({
            url: '/Roles/QueryPage',
            columns: [
                {
                    checkbox: true
                },
                {
                    field: 'id',
                    title: L('Id'),
                    visible: false,
                    sortable: true
                },
                {
                    field: 'displayName',
                    title: L('DisplayName'),
                    sortable: true
                },
                {
                    field: 'name',
                    title: L('Name'),
                },
                {
                    field: 'normalizedName',
                    title: L('NormalizedName'),
                    sortable: true
                },
                {
                    field: 'description',
                    title: L('Description'),
                    sortable: true
                },
                {
                    field: 'isStatic',
                    title: L('IsStatic'),
                    sortable: true
                },
                {
                    title: L('Operation'),
                    formatter: function (value, row, index) {
                        var a_edit = '<a href="javascript:void(0)" title="Edit" class="a_edit" tId="' + row.id + '" roleName="' + row.displayName + '"><i class="fa fa-edit"></i></a>';
                        var a_del = '<a href="javascript:void(0)" title="Remove" class="a_del" tId="' + row.id + '" roleName="' + row.displayName + '"><i class="fa fa-remove"></i></a>';
                        return a_edit + '&nbsp;' + a_del;
                    }
                }
            ]
        });
        _$table.bootstrapTable(options);

        //添加
        $('#btn-add').click(function () {
            $('#RoleCreateModal').modal('show');
        });
        //批量删除
        $('#btn-del').click(function () {
            var _$row = _$table.bootstrapTable('getSelections');//获取table选中的行
            if (_$row.length <= 0) { abp.message.info('请选择您要删除的行', '删除角色'); return false; }
            var roleId = _$row[0].id;
            var roleName = _$row[0].displayName;
            deleteRole(roleId, roleName);
        });
        //删除
        $(document).on('click', '.a_del', function () {
            debugger;
            var roleId = $(this).attr('tId');
            var roleName = $(this).attr('roleName');
            deleteRole(roleId, roleName);
        });
        //编辑
        $(document).on('click', '.a_edit', function () {
            var roleId = $(this).attr("tId");
            $.getModal({
                url: abp.appPath + 'Roles/EditRoleModal',
                data: { roleId: roleId },
                title: 'EditRole',
                modelId: 'modelId',
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var role = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            role.permissions = [];
            var _$permissionCheckboxes = $("input[name='permission']:checked");
            if (_$permissionCheckboxes) {
                for (var permissionIndex = 0; permissionIndex < _$permissionCheckboxes.length; permissionIndex++) {
                    var _$permissionCheckbox = $(_$permissionCheckboxes[permissionIndex]);
                    role.permissions.push(_$permissionCheckbox.val());
                }
            }

            abp.ui.setBusy(_$modal);
            _roleService.create(role).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new role!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshRoleList() {
            location.reload(true); //reload page to see new role!
        }

        function deleteRole(roleId, roleName) {
            abp.message.confirm(
                "Remove Users from Role and delete Role '" + roleName + "'?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        _roleService.delete({
                            id: roleId
                        }).done(function () {
                            refreshRoleList();
                        });
                    }
                }
            );
        }

        _$form.validate({});
    });
})();
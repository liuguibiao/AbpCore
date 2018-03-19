(function () {
    $(function () {
        var _userService = abp.services.app.user;
        var _$modal = $('#UserCreateModal');
        var _$form = _$modal.find('form');
        var _$table = $('#table');

        var options = $.tableParameter({
            url: '/Users/QueryPage',
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
                    field: 'name',
                    title: L('Name'),
                },
                {
                    field: 'userName',
                    title: L('UserName'),
                    sortable: true
                },
                {
                    field: 'surname',
                    title: L('Surname'),
                    sortable: true
                },
                {
                    field: 'emailAddress',
                    title: L('EmailAddress'),
                    sortable: true
                },
                {
                    field: 'isActive',
                    title: L('IsActive'),
                    sortable: true
                },
                {
                    field: 'fullName',
                    title: L('FullName'),
                    sortable: true
                },
                {
                    field: 'lastLoginTime',
                    title: L('LastLoginTime'),
                    sortable: true
                },
                {
                    field: 'creationTime',
                    title: L('CreationTime'),
                    sortable: true
                },
                {
                    title: L('Operation'),
                    formatter: function (value, row, index) {
                        var a_edit = '<a href="javascript:void(0)" title="Edit" class="a_edit" tId="' + row.id + '" name="' + row.name + '"><i class="fa fa-edit"></i></a>';
                        var a_del = '<a href="javascript:void(0)" title="Remove" class="a_del" tId="' + row.id + '" name="' + row.name + '"><i class="fa fa-remove"></i></a>';
                        return a_edit + '&nbsp;' + a_del;
                    }
                }
            ]
        });
        _$table.bootstrapTable(options);

        //添加
        $('#btn-add').click(function () {
            $('#UserCreateModal').modal('show');
        });

        //批量删除
        $('#btn-del').click(function () {
            var _$row = _$table.bootstrapTable('getSelections');//获取table选中的行
            if (_$row.length <= 0) { abp.message.info('请选择您要删除的行', '删除用户'); return false; }

            var userId = _$row[0].id;
            var userName = _$row[0].name;
            deleteUser(userId, userName);
        });
        //删除
        $(document).on('click', '.a_del', function () {
            var userId = $(this).attr('tId');
            var userName = $(this).attr('name');
            deleteUser(userId, userName);
        });
        //编辑
        $(document).on('click', '.a_edit', function () {
            var userId = $(this).attr('tId');
            $.getModal({
                url: abp.appPath + 'Users/EditUserModal?userId=' + userId,
                title: 'EditUsers',
                modelId: 'modelId',
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var user = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            user.roleNames = [];
            var _$roleCheckboxes = $("input[name='role']:checked");
            if (_$roleCheckboxes) {
                for (var roleIndex = 0; roleIndex < _$roleCheckboxes.length; roleIndex++) {
                    var _$roleCheckbox = $(_$roleCheckboxes[roleIndex]);
                    user.roleNames.push(_$roleCheckbox.val());
                }
            }
            user.permissionNames = [];
            var _$permissionCheckboxes = $("input[name='permission']:checked");
            if (_$permissionCheckboxes) {
                for (var permissionIndex = 0; permissionIndex < _$permissionCheckboxes.length; permissionIndex++) {
                    var _$permissionCheckbox = $(_$permissionCheckboxes[permissionIndex]);
                    user.permissionNames.push(_$permissionCheckbox.val());
                }
            }

            abp.ui.setBusy(_$modal);
            _userService.create(user).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new user!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });
        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });
        function refreshUserList() {
            location.reload(true); //reload page to see new user!
        }
        function deleteUser(userId, userName) {
            abp.message.confirm(
                "Delete user '" + userName + "'?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        _userService.delete({
                            id: userId
                        }).done(function () {
                            refreshUserList();
                        });
                    }
                }
            );
        }
        _$form.validate({
            rules: {
                Password: "required",
                ConfirmPassword: {
                    equalTo: "#Password"
                }
            }
        });
    });
})();
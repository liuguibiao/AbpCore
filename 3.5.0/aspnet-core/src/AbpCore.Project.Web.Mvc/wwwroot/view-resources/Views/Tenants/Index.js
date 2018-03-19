(function () {
    $(function () {
        var _$table = $('#table');
        var _tenantService = abp.services.app.tenant;
        var _$modal = $('#TenantCreateModal');
        var _$form = _$modal.find('form');
        var options = $.tableParameter({
            url: '/Tenants/QueryPage',
            columns: [
                {
                    checkbox: true
                },
                {
                    field: 'id',
                    title: L('Id'),
                    visible: true,
                    sortable: true
                },
                {
                    field: 'tenancyName',
                    title: L('TenancyName'),
                    sortable: true
                },
                {
                    field: 'name',
                    title: L('Name'),
                },
                {
                    field: 'isActive',
                    title: L('IsActive'),
                    sortable: true
                },
                {
                    title: L('Operation'),
                    formatter: function (value, row, index) {
                        var a_edit = '<a href="javascript:void(0)" title="Edit" class="a_edit" tId="' + row.id + '" tenancyName="' + row.tenancyName + '"><i class="fa fa-edit"></i></a>';
                        var a_del = '<a href="javascript:void(0)" title="Remove" class="a_del" tId="' + row.id + '" tenancyName="' + row.tenancyName + '"><i class="fa fa-remove"></i></a>';
                        return a_edit + '&nbsp;' + a_del;
                    }
                }
            ]
        });
        _$table.bootstrapTable(options);

        //添加
        $('#btn-add').click(function () {
            $('#TenantCreateModal').modal('show');
        });

        //删除
        $('#btn-del').click(function () {
            var _$row = _$table.bootstrapTable('getSelections');//获取table选中的行
            if (_$row.length <= 0) { abp.message.info('请选择您要删除的行', '删除租户'); return false; }

            var tenantId = _$row[0].id;
            var tenancyName = _$row[0].tenancyName;
            deleteTenant(tenantId, tenancyName);
        });
        //删除
        $(document).on('click', '.a_del', function () {
            var tenantId = $(this).attr('tId');
            var tenancyName = $(this).attr('tenancyName');
            deleteTenant(tenantId, tenancyName);
        });
        //编辑
        $(document).on('click', '.a_edit', function () {
            var tenantId = $(this).attr('tId');
            $.getModal({
                url: abp.appPath + 'Tenants/EditTenantModal',
                data: { tenantId: tenantId },
                title: 'EditTenant',
                modelId: 'modelId',
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var tenant = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js

            abp.ui.setBusy(_$modal);
            _tenantService.create(tenant).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new tenant!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        //刷新
        function refreshTenantList() {
            location.reload(true); //reload page to see new tenant!
        }

        //删除
        function deleteTenant(tenantId, tenancyName) {
            abp.message.confirm(
                "Delete tenant '" + tenancyName + "'?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        _tenantService.delete({
                            id: tenantId
                        }).done(function () {
                            refreshTenantList();
                        });
                    }
                }
            );
        }
        _$form.validate();
    });
})();
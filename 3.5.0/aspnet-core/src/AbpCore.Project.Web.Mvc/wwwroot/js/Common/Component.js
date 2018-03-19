var contentType = contentType || 'application/x-www-form-urlencoded';
//本地化
var L = abp.localization.getSource('Project');
//刷新
var reload = function () { location.reload(true) };
; (function ($, window, document, undefined) {
    $.extend({
        tableParameter: function (options) {
            options = $.extend({}, tableOptions, options || {});
            return options;
        },
        getModal: function (options) {
            $.get({
                url: options.url,
                data: options.data || {},
                success: function (data) {
                    data = data.replace(/F4-ModelId/, options.modelId);
                    data = data.replace(/F4-Title/, L(options.title));
                    var cenId = 'modalCen11aa' + Math.round(Math.random() * 1000);
                    $('#' + options.modelId).remove();
                    $('body').append(data)
                    $('#' + options.modelId).modal('show');
                }
            });
        },
        initTreeData: function (data, parentId) {
            return initTreeData(data, parentId);
        }
    });
    $.fn.selectTree = function (options, param) {
        if (typeof options == 'string') {
            return $.fn.selectTree.methods[options](this, param);
        }
        var $this = $(this);
        options = $.extend({}, $.fn.selectTree.defaults, options || {});
        if (!options.data)
            return;
        var oData = $.extend(true, [], options.data);
        oData.unshift({ id: 0, text: "无" });
        var dataStr = JSON.stringify(oData);
        dataStr = dataStr.replace(/displayName/g, 'text');
        $this.tree = $('<div style="display:none;"></div>');
        $this.treeValue = $('<input type="hidden" name="' + $this.attr('name') + '"/>');
        $this.attr('name','');
        $this.tree.treeview({
            data: initTreeData(JSON.parse(dataStr))
        });
        $this.after($this.tree);
        $this.after($this.treeValue);
        $this.click(function () {
            var display = $this.tree.css("display");
            if (display == 'none')
                $this.tree.css('display', 'block');
            else
                $this.tree.css('display', 'none');
        });
        $this.tree.on('nodeSelected', function (event, data) {
            $this.tree.css('display', 'none');
            $this.val(data.text);
            $this.treeValue.val(data.id);
            if (data.id == 0)
                $this.treeValue.val('');
        });
    }
    $.fn.selectTree.methods = {

    };
    $.fn.selectTree.defaults = {
        data: null,
    };
    function initTreeData(data, parentId) {
        var result = [];
        for (var i in data) {
            if (data[i].parentId == parentId) {
                var temp = data[i];
                temp.state = {
                    disabled: false,
                    expanded: false
                }
                result.push(temp);
                temp = initTreeData(data, data[i].id);
                if (temp.length > 0) {
                    data[i].nodes = temp;
                    //data[i].tags = ['' + temp.length + ''];
                }
            }
        }
        return result;
    }
})(jQuery, window, document);
var tableOptions = {
    method: 'get', //请求方式（*）
    toolbar: '#toolbar', //工具按钮用哪个容器
    striped: true, //是否显示行间隔色
    cache: false, //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
    pagination: true, //是否显示分页（*）
    sortable: true, //是否启用排序
    sortOrder: "asc", //排序方式
    sidePagination: "server", //分页方式：client客户端分页，server服务端分页（*）
    pageNumber: 1, //初始化加载第一页，默认第一页
    pageSize: 20, //每页的记录行数（*）
    pageList: [20, 50, 80, 100], //可供选择的每页的行数（*）
    search: true, //是否显示表格搜索
    strictSearch: true,
    showColumns: true,          //是否显示所有的列
    showRefresh: true,          //是否显示刷新按钮
    queryParams: queryParams,
    responseHandler: responseHandler,
    minimumCountColumns: 2,     //最少允许的列数
    clickToSelect: true,        //是否启用点击选中行
    minHeight: 300,
    uniqueId: "ID",             //每一行的唯一标识，一般为主键列
    showToggle: false,           //是否显示详细视图和列表视图的切换按钮
    cardView: false,            //是否显示详细视图
    detailView: false,          //是否显示父子表
    singleSelect: false
};
function queryParams(params) {
    var params = params || {};
    var sorting = params.order == 'asc' ? params.sort : '';
    return {
        SkipCount: params.offset,
        MaxResultCount: params.limit,
        Search: params.search,//全局搜索参数
        Sorting: sorting,//排序字段
        Order: params.order
    };
}
function responseHandler(res) {
    var res = res || {};
    return {
        total: res.result.totalCount,//总页数
        rows: res.result.items   //数据
    };
};
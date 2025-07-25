var tas_recruitingSandboxForm = {

    init: function () {
        this.initLeadSourceDDL();
        this.initStatusDDL();
        this.initTypeDDL();
        this.initCompanyDDL();
        this.initStateDDL();
        this.initHierarchyDDL();
    },

    initLeadSourceDDL: function (selectedValue) {
        $('#leadSourceId').dxSelectBox({
            dataSource: LeadSource,
            displayExpr: 'text',
            valueExpr: 'value',
            value: selectedValue,
            searchEnabled: true,
            width: '100%',
            placeholder: 'Search',
            showClearButton: true,
            dropDownOptions: {
                height: 'auto',
            },
            pagingEnabled: true,
            searchTimeout: 500,
            onValueChanged: function (e) {
            },
        });
    },

    initStatusDDL: function (selectedValue) {
        $('#statusId').dxSelectBox({
            dataSource: Status,
            displayExpr: 'text',
            valueExpr: 'value',
            value: selectedValue,
            searchEnabled: true,
            width: '100%',
            placeholder: 'Search',
            showClearButton: true,
            dropDownOptions: {
                height: 'auto',
            },
            pagingEnabled: true,
            searchTimeout: 500,
            onValueChanged: function (e) {
            },
        });
    },

    initTypeDDL: function (selectedValue) {
        $('#typeId').dxSelectBox({
            dataSource: Type,
            displayExpr: 'text',
            valueExpr: 'value',
            value: selectedValue,
            searchEnabled: true,
            width: '100%',
            placeholder: 'Search',
            showClearButton: true,
            dropDownOptions: {
                height: 'auto',
            },
            pagingEnabled: true,
            searchTimeout: 500,
            onValueChanged: function (e) {
            },
        });
    },

    initCompanyDDL: function (selectedValue) {
        $('#currentCompanyId').dxSelectBox({
            dataSource: Company,
            displayExpr: 'text',
            valueExpr: 'value',
            value: selectedValue,
            searchEnabled: true,
            width: '100%',
            placeholder: 'Search',
            showClearButton: true,
            dropDownOptions: {
                height: 'auto',
            },
            pagingEnabled: true,
            searchTimeout: 500,
            onValueChanged: function (e) {
            },
        });
    },

    initStateDDL: function (selectedValue) {
        $('#stateId').dxSelectBox({
            dataSource: State,
            displayExpr: 'text',
            valueExpr: 'value',
            value: selectedValue,
            searchEnabled: true,
            width: '100%',
            placeholder: 'Search',
            showClearButton: true,
            dropDownOptions: {
                height: 'auto',
            },
            pagingEnabled: true,
            searchTimeout: 500,
            onValueChanged: function (e) {
            },
        });
    },

    initHierarchyDDL: function (selectedValue) {
        $('#hierarchyId').dxSelectBox({
            dataSource: Hierarchy,
            displayExpr: 'text',
            valueExpr: 'value',
            value: selectedValue,
            searchEnabled: true,
            width: '100%',
            placeholder: 'Search',
            showClearButton: true,
            dropDownOptions: {
                height: 'auto',
            },
            pagingEnabled: true,
            searchTimeout: 500,
            onValueChanged: function (e) {
            },
        });
    },
};

$(document).ready(function () {
    tas_recruitingSandboxForm.init();
});
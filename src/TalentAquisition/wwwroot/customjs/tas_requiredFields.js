var tas_requiredFields = {
    allFieldsGrid,
    selectedMilestoneId: null,
    selectedMilestoneName: null,
    allFieldsData: [],

    init: function () {
        tas_requiredFields.getAll();
        tas_requiredFields.bindEvents();
    },

    getAll: function () {
        tas_requiredFields.initializeGrid();
        $.ajax({
            url: '/RequiredFields/GetAll',
            type: 'GET',
            success: function (data) {
                tas_requiredFields.allFieldsData = data.data;
                tas_requiredFields.initMilestoneDDL();
            }
        });
    },

    bindEvents: function () {
        $('#reset').click(tas_requiredFields.handleResetClick.bind(this));

        $('#save').click(tas_requiredFields.handleSaveClick.bind(this));
    },

    initializeGrid: function () {
        tas_requiredFields.allFieldsGrid = $("#allFieldsGrid").dxDataGrid({
            dataSource: [],
            columns: [
                {
                    dataField: "fieldId",
                    caption: "Field Id",
                    width: 60
                },
                {
                    dataField: "fieldName",
                    caption: "Field Name",
                    width: 150
                },
                {
                    dataField: "dataType",
                    caption: "Data Type",
                    width: 100
                },
                {
                    dataField: "tabId",
                    caption: "Tab Id",
                    width: 100,
                    visible: false
                },
                {
                    dataField: "description",
                    caption: "Description"
                },
                {
                    dataField: "requiredInEmployee",
                    caption: "Required For Employee",
                    width: 160,
                    dataType: "boolean",
                    cellTemplate: function (container, options) {
                        $('<div>').dxCheckBox({
                            value: options.data.milestoneId > 0,
                            onValueChanged: function (e) {
                                var data = options.data;
                                data.milestoneId = e.value ? data.tabId : 0;
                                tas_requiredFields.allFieldsGrid.getDataSource().store().update(data.fieldId, data);
                            }
                        }).appendTo(container);
                    }
                },
                {
                    dataField: "requiredInBranch",
                    caption: "Required For Branch",
                    width: 160,
                    dataType: "boolean",
                    cellTemplate: function (container, options) {
                        $('<div>').dxCheckBox({
                            value: options.data.milestoneIdBranch > 0,
                            onValueChanged: function (e) {
                                var data = options.data;
                                data.milestoneIdBranch = e.value ? data.tabId : 0;
                                tas_requiredFields.allFieldsGrid.getDataSource().store().update(data.fieldId, data);
                            }
                        }).appendTo(container);
                    }
                },
                {
                    dataField: "milestoneId",
                    visible: false
                },
                {
                    dataField: "milestoneIdBranch",
                    visible: false
                }
            ],
            filterRow: {
                visible: true
            },
            searchPanel: {
                visible: true,
                width: 240,
                placeholder: "Search..."
            },
            showBorders: true,
            columnAutoWidth: false,
            wordWrapEnabled: true,
            showRowLines: true,
            rowAlternationEnabled: true,
            paging: {
                pageSize: 10
            },
            pager: {
                showPageSizeSelector: true,
                allowedPageSizes: [5, 10, 20, 50, 100],
                showInfo: true
            },
            editing: {
                mode: "cell",
                allowUpdating: true
            }
        }).dxDataGrid("instance");
    },

    initMilestoneDDL: function (selectedValue) {
        $('#milestoneId').dxSelectBox({
            dataSource: Milestones,
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
                tas_requiredFields.selectedMilestoneId = e.value;
                tas_requiredFields.selectedMilestoneName = e.valueExpr;

                if (!tas_requiredFields.selectedMilestoneId) {
                    tas_requiredFields.allFieldsGrid.option("dataSource", []);
                    $('#milestoneNameHeading').html('');
                } else {
                    const filteredData = tas_requiredFields.allFieldsData.filter(field => field.tabId == tas_requiredFields.selectedMilestoneId);
                    tas_requiredFields.allFieldsGrid.option("dataSource", filteredData);
                    $('#milestoneNameHeading').html(' for ' + tas_requiredFields.selectedMilestoneName);
                    tas_requiredFields.allFieldsGrid.refresh();
                }
            },
        });
        $('#milestoneId').dxSelectBox('instance').option('value', 1);
    },

    handleSaveClick: function () {
        const selectBox = $("#milestoneId").dxSelectBox("instance");
        const milestoneIds = selectBox.option("dataSource").map(item => item.value);
        let validationErrors = [];

        milestoneIds.forEach(milestoneId => {
            const hasEmployeeRequired = tas_requiredFields.allFieldsData.some(field =>
                field.milestoneId == milestoneId
            );

            const hasBranchRequired = tas_requiredFields.allFieldsData.some(field =>
                field.milestoneIdBranch == milestoneId
            );

            if (!hasEmployeeRequired || !hasBranchRequired) {
                const milestoneName = milestoneId;
                let milestoneErrors = [];

                if (!hasEmployeeRequired) {
                    milestoneErrors.push("Employee requirement missing");
                }
                if (!hasBranchRequired) {
                    milestoneErrors.push("Branch requirement missing");
                }

                validationErrors.push({
                    milestoneName: milestoneName,
                    errors: milestoneErrors
                });
            }
        });

        if (validationErrors.length > 0) {
            let errorMessage = "Validation failed for:\n";

            validationErrors.forEach(error => {
                errorMessage += `\n- ${error.milestoneName}: ${error.errors.join(", ")}`;
            });

            errorMessage += "\n\nEach milestone must have at least one Employee and one Branch required field.";

            tas_helper.notify(errorMessage, 2);

            return;
        } else {

            const field = tas_requiredFields.allFieldsData.map(field => ({
                fieldId: field.fieldId,
                fieldName: field.fieldName || null,
                fieldIdentifier: field.fieldIdentifier,
                milestoneId: field.milestoneId || null,
                description: field.description || null,
                dataType: field.dataType || null,
                isDeleted: field.isDeleted || false,
                tabId: field.tabId || null,
                milestoneIdBranch: field.milestoneIdBranch || null
            }));

            console.log(field)
            $.ajax({
                url: '/RequiredFields/Edit',
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(field),
                success: function (response) {
                    tas_helper.notify("Fields saved successfully", 1);
                    tas_requiredFields.getAll();
                },
                error: function (xhr, status, error) {
                    tas_helper.notify("Error saving fields: " + error, 2);
                }
            });
        }
    },

    handleResetClick: function () {
        DevExpress.ui.dialog.confirm(
            `Are you sure you want to reset all required fields for milestone ${tas_requiredFields.selectedMilestoneName}?`,
            "Confirm Reset"
        ).done(function (dialogResult) {
            if (!dialogResult) {
                return;
            }

            const currentGridData = tas_requiredFields.allFieldsGrid.option("dataSource");

            const updatedGridData = currentGridData.map(item => {
                const updatedItem = { ...item };

                if (updatedItem.milestoneId == tas_requiredFields.selectedMilestoneId) {
                    updatedItem.milestoneId = 0;
                }
                if (updatedItem.milestoneIdBranch == tas_requiredFields.selectedMilestoneId) {
                    updatedItem.milestoneIdBranch = 0;
                }

                const masterIndex = tas_requiredFields.allFieldsData.findIndex(f => f.fieldId === updatedItem.fieldId);
                if (masterIndex >= 0) {
                    tas_requiredFields.allFieldsData[masterIndex] = { ...updatedItem };
                }

                return updatedItem;
            });
            const filteredData = tas_requiredFields.allFieldsData.filter(field => field.tabId == tas_requiredFields.selectedMilestoneId);

            tas_requiredFields.allFieldsGrid.option("dataSource", filteredData);
            tas_requiredFields.allFieldsGrid.refresh();

            tas_helper.notify(`Reset all fields for milestone ${tas_requiredFields.selectedMilestoneName}`, 1);
        });
    },
};

$(document).ready(function () {
    tas_requiredFields.init();
});
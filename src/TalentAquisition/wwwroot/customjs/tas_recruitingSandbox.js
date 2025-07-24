var tas_recruitingSandbox = {

    init: function () {
        this.initializeGrid();
    },

    initializeGrid: function () {
        tas_ajaxHelper.get(`/RecruitingSandbox/GetAll`, (data) => {
            this.createGrid(data)
        });
    },

    createGrid(dataSrc) {
        var col = [
            {
                caption: "Source",
                dataField: "LeadSource",
                width: tas_helper.isMobile() ? 40 : 80
            },
            {
                caption: "",
                dataField: "TransID",
                width: 40,
                allowFiltering: false,
                allowSorting: false,
                cellTemplate: function (container, options) {
                    let formURL = '';
                    var getFileBaseUrl = '/RecruitingSandbox/GetFile';
                    var imageUrl = getFileBaseUrl + '?name=' + options.data.Profile;
                    let viewOnlyFormURL = '';
                    if (options.data.Status == 'Employee' || options.data.Status == 'Candidate in progress') {
                        formURL = '/Lead/_GetLeadByID/' + options.value;
                        viewOnlyFormURL = '/Lead/_GetLeadByID/' + options.value + '?isView=true';
                    } else {
                        formURL = '/RecruitingSandbox/Edit/' + options.value;
                        viewOnlyFormURL = '/RecruitingSandbox/Edit/' + options.value + '?isView=true';
                    }
                    if (options.data.Note == null) {
                        $("<div>", { "class": "img-container" })
                            .append($("<button class='ViewEmployee btn CanViewEmployee BtnViewDropdown dropdown-toggle' data-toggle='dropdown' id='" + options.value + "'  actionfor='View'><i class='icon-radio-checked'></i></button><div class='hoverbx'><div class='dp-hoverr'><img src ='" + imageUrl + "' /><div class='dp-contact'><h4>" + options.data.CandidateName + "</h4><a href='mailto:" + options.data.Email + "'>" + options.data.Email + "</a><a href='tel:" + options.data.Phone + "'>" + options.data.Phone + "</a></div></div><div class='hoveraction'><a style='display: block;' href='" + formURL + "' class='dropdown-item ViewEmployee  CanEditEmployee' title='Edit'><i class='glyphicon glyphicon-edit'></i></a><a style='display: block;' href='" + viewOnlyFormURL + "' class='dropdown-item ViewDetails' title='View Details'><i class='glyphicon glyphicon-search'></i></a><a style='display: block;' href='#' class='CanDeleteEmployee dropdown-item' title='Delete' id='" + options.value + "' data-toggle='modal' data-target='#deletemodal'><i class='icon-bin'></i></a> <a style='display: " + IsAdd + ";' href='#' class='dropdown-item CanAddNote' id='" + options.value + "' title='Add Note' data-toggle='modal' data-target='#notemodal'><i class='glyphicon glyphicon-plus'></i></a></div></div>", { "src": options.value }))
                            .appendTo(container);
                    } else {
                        $("<div>", { "class": "img-container" })
                            .append($("<button class='ViewEmployee btn CanViewEmployee BtnViewDropdown dropdown-toggle' data-toggle='dropdown' id='" + options.value + "'  actionfor='View'><i class='icon-radio-checked'></i></button><div class='hoverbx'><div class='dp-hoverr'><img src ='" + imageUrl + "' /><div class='dp-contact'><h4>" + options.data.CandidateName + "</h4><a href='mailto:" + options.data.Email + "'>" + options.data.Email + "</a><a href='tel:" + options.data.Phone + "'>" + options.data.Phone + "</a></div></div><div class='hoveraction'><a style='display: block;' href='#' class='dropdown-item viewnote'  data-toggle='popover' title='Modified on: " + options.data.NoteTime + " - " + options.data.Title + "' data-content='" + options.data.Note + "'><i class='icon-eye'></i></a><a style='display: block;' href='" + formURL + "' class='dropdown-item ViewEmployee  CanEditEmployee' title='Edit'><i class='glyphicon glyphicon-edit'></i></a><a style='display: block;' href='" + viewOnlyFormURL + "' class='dropdown-item ViewDetails' title='View Details'><i class='glyphicon glyphicon-search'></i></a><a style='display: block;' href='#' class='CanDeleteEmployee dropdown-item' title='Delete' id='" + options.value + "' data-toggle='modal' data-target='#deletemodal'><i class='icon-bin'></i></a> <a style='display: " + IsAdd + ";' href='#' class='dropdown-item CanAddNote' id='" + options.value + "' title='Add Note' data-toggle='modal' data-target='#notemodal'><i class='glyphicon glyphicon-plus'></i></a></div></div>", { "src": options.value }))
                            .appendTo(container);
                    }
                }
            },
            {
                caption: "Candidate Name",
                dataField: "CandidateName",
            },
            {
                caption: "Phone",
                dataField: "Phone",
            },
            {
                caption: "Comp.",
                dataField: "CurrentCompany",

            },
            {
                caption: "St.",
                dataField: "HomeLocation",
            },
            {
                caption: "Status",
                dataField: "Status",
                visible: tas_helper.isMobile() ? false : true
            },
            {
                dataField: "Volume",
                caption: "Vol.",
                dataType: "number",
                customizeText: function (cellInfo) {
                    if (cellInfo.value == null || cellInfo.value == 0.00) return "$0.00";
                    return "$" + (cellInfo.value / 1_000_000).toFixed(2) + "M";
                }
            },
            {
                caption: "NMLS",
                dataField: "NMLS",
                visible: tas_helper.isMobile() ? false : true
            },
            {
                caption: "Last Touched",
                dataField: "LastTouch",
                dataType: "number",
                visible: tas_helper.isMobile() ? false : true
            },
            {
                caption: "Action Items",
                dataField: "ActionItems",
                visible: false
            },
            {
                caption: "Address",
                dataField: "Address",
                visible: false
            },
            {
                caption: "Anticipated Start Date",
                dataField: "AnticipatedStartDate",
                dataType: "date",
                format: "MM/dd/yyyy",
                visible: false
            },
            {
                caption: "Branch",
                dataField: "Branch",
                visible: false
            },
            {
                caption: "City",
                dataField: "City",
                visible: false
            },
            {
                caption: "Gifts",
                dataField: "Gifts",
                visible: false
            },
            {
                caption: "Hierarchy",
                dataField: "Hierarchy",
                visible: false
            },
            {
                caption: "Intro Date",
                dataField: "IntroductionDate",
                dataType: "date",
                format: "MM/dd/yyyy",
                visible: false
            },
            {
                caption: "Job Title",
                dataField: "JobTitle",
                visible: false
            },
            {
                caption: "LinkedIn Profile",
                dataField: "LinkedInProfile",
                visible: tas_helper.isMobile() ? false : true
            },
            {
                caption: "Ownership",
                dataField: "Ownership",
                visible: false
            },
            {
                caption: "Reference",
                dataField: "Reference",
                visible: false
            },
            {
                caption: "Role Type",
                dataField: "RoleType",
                visible: false
            },
            {
                caption: "Type",
                dataField: "Type",
                visible: false
            },
            {
                caption: "Unique Products",
                dataField: "UniqueProducts",
                visible: false
            },
            {
                caption: "Unfollow",
                dataField: "isUnfollow",
                visible: false
            },
            {
                caption: "Zip Code",
                dataField: "ZipCode",
                visible: false
            }
        ]
        this.grid = tas_helper.dxGridbinding('#gridContainer', col, dataSrc, "Lead List");
    },
};

$(document).ready(function () {
    tas_recruitingSandbox.init();
});
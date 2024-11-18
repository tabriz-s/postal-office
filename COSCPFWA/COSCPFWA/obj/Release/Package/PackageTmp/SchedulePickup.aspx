<%@ Page Title="Schedule Pickup" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SchedulePickup.aspx.cs" Inherits="COSCPFWA.SchedulePickup" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="text-center mb-4">
            <h2 class="display-4">Schedule a Pickup</h2>
            <p class="lead">Select a pickup time and location to schedule your package pickup.</p>
        </div>

        <asp:Label ID="lblMessage" runat="server" CssClass="message-label alert alert-info mb-4" Visible="false"></asp:Label>

        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card shadow-lg">
                    <div class="card-header text-white text-center" style="background-color:#0d47a1;">
                        <h5 class="card-title mb-0">Pickup Schedule</h5>
                    </div>
                    <div class="card-body">
                        <div class="form-group text-center">
                            <label for="txtPickupDate">Pickup Date</label>
                            <div class="d-flex justify-content-center">
                                <asp:TextBox ID="txtPickupDate" runat="server" Placeholder="Select Pickup Date" CssClass="form-control datepicker" />
                            </div>
                        </div>
                        <div class="form-group text-center">
                            <label for="txtPickupTime">Pickup Time</label>
                            <div class="d-flex justify-content-center">
                                <asp:TextBox ID="txtPickupTime" runat="server" Placeholder="Select Pickup Time" CssClass="form-control timepicker" />
                            </div>
                        </div>
                        <div class="form-group text-center">
                            <label for="ddlLocation">Pickup Location</label>
                            <div class="d-flex justify-content-center">
                                <asp:DropDownList ID="ddlLocation" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Select Location" Value="" />
                                    <asp:ListItem Text="Location 1" Value="1" />
                                    <asp:ListItem Text="Location 2" Value="2" />
                                    <asp:ListItem Text="Location 3" Value="3" />
                                    <asp:ListItem Text="Location 4" Value="4" />
                                    <asp:ListItem Text="Location 5" Value="5" />
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group text-center mt-4">
                            <asp:Button ID="btnSchedulePickup" runat="server" Text="Schedule Pickup" CssClass="btn btn-primary btn-lg" OnClick="btnSchedulePickup_Click" style="background-color:#0d47a1;" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="ScriptsContent" ContentPlaceHolderID="ScriptsContent" runat="server">
    <!-- Datepicker and Timepicker Scripts -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/css/bootstrap-datepicker.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-timepicker/0.5.2/css/bootstrap-timepicker.min.css" />
    
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/js/bootstrap-datepicker.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-timepicker/0.5.2/js/bootstrap-timepicker.min.js"></script>

    <script>
        // Pickup Date (weekdays only)
        $(document).ready(function () {
            $('.datepicker').datepicker({
                format: 'yyyy/mm/dd',
                daysOfWeekDisabled: [0], // Disable Sundays (0 = Sunday)
                autoclose: true
            });

            // Pickup Time (12-hour format)
            $('.timepicker').timepicker({
                showMeridian: true,  // enable AM/PM
                minuteStep: 30,  // 30 minute intervals
                defaultTime: false,  // no default time
                showSeconds: false,  // disable seconds
                showInputs: true,  // show input box for manual entry
                maxTime: '07:00 PM',
                minTime: '08:00 AM'
            });

            // available time options based on the selected date
            $('.datepicker').on('changeDate', function (e) {
                var selectedDate = e.format('yyyy/mm/dd');
                var selectedDay = new Date(selectedDate).getDay();

                if (selectedDay === 0) { // Sunday
                    $('.timepicker').timepicker('disable');
                } else if (selectedDay === 6) { // Saturday
                    $('.timepicker').timepicker('setTime', '09:00 AM');
                    $('.timepicker').timepicker('option', 'minTime', '09:00 AM');
                    $('.timepicker').timepicker('option', 'maxTime', '03:00 PM');
                } else { // Weekdays
                    $('.timepicker').timepicker('setTime', '08:00 AM');
                    $('.timepicker').timepicker('option', 'minTime', '08:00 AM');
                    $('.timepicker').timepicker('option', 'maxTime', '07:00 PM');
                }
            });
        });
    </script>
</asp:Content>

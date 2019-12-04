import { Component, OnInit, Inject, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
declare var $: any;
@Component({
  selector: 'app-search-list',
  templateUrl: './search-list.component.html',
  styleUrls: ['./search-list.component.css'],
  encapsulation: ViewEncapsulation.None,
})

export class SearchListComponent implements OnInit {

  frm: any = {};
  SelectedSeat: any = [];
  PickUPPointList = [];
  DropPointList = [];
  SourceID: any = 6;
  DestinationID: any = 13;
  JournyDate: any;

  SeatList = [];
  BusSeatList = [];
  TSeatPrice = 0;
  TDiscount = 0;
  GST = 0;
  TotalFare = 0;
  TravelInsurance = 0;
  IsBindSeat = false;
  IsOpenSeatChart = false;
  SourceList: any = [];
  BusList: any = [];
  SelectedSeat1: any;
  isShowPersonalDetails: boolean = false;
  PickUpPoint: any;
  DropPoint: any;
  TravelInsurancerance: any = 0;
  SeatTempate: any = "Two"
  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    http.get<any>(baseUrl + 'api/GetBusList?SourceID=6&DestinationID=13&JourneyDate=11/11/2020').subscribe(result => {
      // console.log(result);
      this.SourceList = result.SourceList;
      this.BusList = result.BusList;
      console.log(this.SourceList);
      //console.clear();
      //alert(JSON.stringify(result.SeatList))
      this.BusSeatList = result.SeatList;

      console.log(this.BusList);
    }, error => console.error(error));
  }
  ngOnInit() {
  }

  CloseBusSeatDetails(i) {
    this.IsOpenSeatChart = false;
    this.BusList[i].IsOpenSeatChart = false;
  }

  OpenSeat(a, b, c) {
    //alert(a);

    this.http.get<any>(this.baseUrl + 'api/GetBusSeatList?RouteID=' + this.BusList[a].RouteID + '&DestinationID=13&JourneyDate=11/11/2020&SourceID=6&SeatTempate=' + this.SeatTempate).subscribe(result => {
      console.log(result);
      this.IsBindSeat = true;

      this.BusSeatList = result.SeatList;
      this.BusList[a].IsOpenSeatChart = true;
      console.log(result.models.PickUpPointList);
      this.PickUPPointList = result.models.PickUpPointList;
      this.DropPointList = result.models.DropPointList;





    }, error => console.error(error));
  }
  SelectSeat(seat, index) {


    if ($("#" + index + "_S" + seat).hasClass('SeatHold')) {
      return false;
    }



    if ($("#" + index + "_S" + seat).hasClass('BookSeat')) {
      $("#" + index + "_S" + seat).removeClass('BookSeat');
      this.TSeatPrice = this.TSeatPrice - parseInt(this.BusSeatList[seat].SeatPrice);
      this.TDiscount = this.TDiscount - parseInt(this.BusSeatList[seat].SeatDiscount);
      this.SelectedSeat.pop(seat);
    }
    else {
      if (this.SelectedSeat.length == 6) {
        return false;
      }

      this.TSeatPrice = this.TSeatPrice + parseInt(this.BusSeatList[seat].SeatPrice);
      this.TDiscount = this.TDiscount + parseInt(this.BusSeatList[seat].SeatDiscount);

      $("#" + index + "_S" + seat).addClass('BookSeat');
      this.SelectedSeat.push(seat);
    }
    this.SelectedSeat1 = this.SelectedSeat.join();





  }
  OpenPersonalDetails() {
    this.isShowPersonalDetails = true;


    $('body').addClass('stop-scrolling')
    //
    this.SeatList = [];
    for (var i = 0; i < this.SelectedSeat.length; i++) {
      this.SeatList.push({ 'SeatNo': this.SelectedSeat[i], 'Gender': 'Male', Name: '', Age: '' });
    }

    this.TotalFare = this.TSeatPrice + (this.TDiscount * 5 / 100);


    $("#divPersonalDetails").show();

    $('#divPersonalDetails').on('blur change', this.CheckValueIsFillOrNot);



    //$("#divPersonalDetails").show();
  }

   CheckValueIsFillOrNot() {
    var Contain = "";
    $("#divpassengerDetails :text").each(function () {
        console.clear();
        console.log($(this).val());
        // Contain += $(this).val() + "$";
        if ($(this).val() == '') {
            $(this).addClass('required')

        }
        else {
            $(this).removeClass('required')
        }
    });
}


  Cancel() {
    $('body').removeClass('stop-scrolling')
    // $("#divPersonalDetails").hide();
    this.isShowPersonalDetails = false;
  }

  ValidateForm() {
    var _Flag = true;

    for (var i = 0; i < this.SeatList.length; i++) {
      if (this.SeatList[i].Name == '') {
        $("#" + i + "_Name").addClass('required');
        _Flag = false;
        //  break;
      }
      if (this.SeatList[i].Age == '') {
        $("#" + i + "_Age").addClass('required');
        _Flag = false;
        //   break;
      }






      // this.SeatList.push({ 'SeatNo': this.SelectedSeat[i], 'Gender': 'Male' });
    }
    return _Flag;

  }

  submitForm() {
    if (this.ValidateForm() == false) {
      // $("#btnPay").click();
      //alert('Please Fill all details.');
      // return;
    }
    // return;
    //  alert($("#JourneyDate").val());
    // return;

    const config = new HttpHeaders().set('Content-Type', 'application/json')
      .set('Access-Control-Allow-Origin', '*')



    this.frm = {};


    var formData: any = new FormData();
    formData.append("SourceID", '11');
    formData.append("DestinationID", '13');


    this.frm.PickUpPoint = this.PickUpPoint;//$("#PickUpPoint").val();
    this.frm.DropPoint = this.DropPoint;// $("#DropPoint").val();

    this.frm.SourceID = $("#SourceID").val();
    this.frm.DestinationID = $("#DestinationID").val();
    this.frm.TicketNo = $("#TicketNo").val();
    this.frm.Source = $("#Source").val();
    this.frm.Destination = $("#Destination").val();
    this.frm.PassengerList = [];
    this.frm.Email = $("#txtEmail").val();
    this.frm.Name = $("#0_Name").val();
    this.frm.MobileNo = $("#MobileNo").val();
    this.frm.JourneyDate = $("#JourneyDate").val()
    this.frm.MobileCountryCode = $("#MobileCountryCode").val();
    this.frm.RouteID = $("#RouteID").val();
    this.frm.TravelInsuranceAmount = this.TravelInsurance;
    this.frm.IsTravelInsurance = parseInt(this.TravelInsurancerance) > 0 ? 1 : 0;
    this.frm.GSTAmount = this.TSeatPrice * 5 / 100;
    this.frm.TotalPayableAmount = this.TotalFare;
    this.frm.TotalAmount = this.TSeatPrice;

    //for (var i = 0; i < this.SelectedSeat.length; i++) {
    //    this.SeatList.push({ 'SeatNo': this.SelectedSeat[i], 'Gender': 'Male' });
    //}
    console.log(this.frm);
    for (var i = 0; i < this.SeatList.length; i++) {
      this.frm.PassengerList.push({
        'Name': this.SeatList[i].Name,
        'SeatNo': this.SeatList[i].SeatNo,
        'Age': this.SeatList[i].Age,
        'Gender': this.SeatList[i].Gender
      });
      // this.SeatList.push({ 'SeatNo': this.SelectedSeat[i], 'Gender': 'Male' });
    }



    this.http.post<any>(this.baseUrl + "api/SaveTicket", this.frm, { headers: config }).subscribe(r => {
      //console.log(r);
      $("#btnPay").click();
    }
    );



    //console.log(this.frm);
    //, new { @ng_model = "frm.IPAddress" }
    //OpenPaymentPopUP(this.TotalFare * 100, $("#0_Name").val(), $("#txtEmail").val(), $("#MobileNo").val());


    //  console.log(JSON.stringify(this.frm));
  }

  UpdateDate() {
    setTimeout(function () {
      this.$apply(function () {
        this.frm.DateOfBirth = $("#DateOfBirth").val();
        this.frm.EstimatedDueDate = $("#EstimatedDueDate").val();
        this.frm.LastPeriodDate = $("#LastPeriodDate").val();
      });
    }, 1000);
  }
  Swap() {

  }
  Modify() {

  }






}

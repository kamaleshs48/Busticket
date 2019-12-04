import { Component, OnInit, Inject, ViewEncapsulation } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LOCAL_STORAGE,WebStorageService,SESSION_STORAGE } from 'angular-webstorage-service';

declare var $: any;
const now = new Date();
@Component({
  selector: 'app-search-list',
  templateUrl: './search-list.component.html',
  styleUrls: ['./search-list.component.css'],
  encapsulation: ViewEncapsulation.None,
})

export class SearchListComponent implements OnInit {

  RouteID: any;
  frm: any = {};
  SelectedSeat: any = [];
  PickUPPointList = [];
  DropPointList = [];
  SourceID: any = 6;
  DestinationID: any = 13;
  JournyDate: any;
  JournyDateModels:any;
  TicketNo:any;

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
  PickUpPoint: any='0';
  DropPoint: any='0';
  TravelInsurancerance: any = 0;
  SeatTempate: any = ""
  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string,
    private activatedRoute: ActivatedRoute,
    @Inject(SESSION_STORAGE) private storage: WebStorageService

  ) {


    this.activatedRoute.queryParams.subscribe(params => {
      this.SourceID = params['Source'];
      this.DestinationID = params['Destination'];
      this.JournyDate = params["JournyDate"];
      // $("#JournyDate").val(this.JournyDate);
      this.JournyDateModels = { year: now.getFullYear(), month: now.getMonth() + 1, day: now.getDate() };

      // console.log('JournyDate  ' +this.JournyDate.spilt('/')[2]);
    });




    http.get<any>(baseUrl + 'api/GetBusList?SourceID='+this.SourceID+'&DestinationID='+this.DestinationID+'&JourneyDate='+ this.JournyDate).subscribe(result => {
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
    this.RouteID = this.BusList[a].RouteID;
    this.SeatTempate=this.BusList[a].SeatTempate;
    this.http.get<any>(this.baseUrl + 'api/GetBusSeatList?RouteID=' + this.BusList[a].RouteID + '&DestinationID=' + this.DestinationID + '&JourneyDate=' + this.JournyDate +
      '&SourceID=' + this.SourceID + '&SeatTempate=' + this.SeatTempate).subscribe(result => {
        console.log(result);
        this.IsBindSeat = true;

        this.BusSeatList = result.SeatList;
        this.BusList[a].IsOpenSeatChart = true;
        console.log(result.models.PickUpPointList);
        this.PickUPPointList = result.models.PickUpPointList;
        this.DropPointList = result.models.DropPointList;
        this.TicketNo=result.models.TicketNo;
        this.storage.set('TicketNo',this.TicketNo);
//this.PickUpPoint=1;





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
     // this.SelectedSeat.pop(seat);

     this.SelectedSeat=this.arrayRemove( this.SelectedSeat,seat );

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

   arrayRemove(arr, value) {

    return arr.filter(function(ele){
        return ele != value;
    });
 
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
      else
      {
        $("#" + i + "_Name").removeClass('required');
      }
      if (this.SeatList[i].Age == '') {
        $("#" + i + "_Age").addClass('required');
        _Flag = false;
        //   break;
      }
      else
      {
        $("#" + i + "_Age").removeClass('required');
      }
     // this.SeatList.push({ 'SeatNo': this.SelectedSeat[i], 'Gender': 'Male' });
    }

   if( $("#" + "txtEmail").val()=='')
   {
    $("#" +  "txtEmail").addClass('required');
    _Flag = false;
   }
   else
   {
    $("#" +  "txtEmail").removeClass('required');
   }

   if( $("#" + "MobileNo").val()=='')
   {
    $("#" +  "MobileNo").addClass('required');
    _Flag = false;
   }
   else
   {
    $("#" +  "MobileNo").removeClass('required');
   }



    return _Flag;

  }

  submitForm() {
    if (this.ValidateForm() == false) {
      // $("#btnPay").click();
      alert('Please Fill all details.');
     return;
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

    this.frm.SourceID = this.SourceID;
    this.frm.DestinationID = this.DestinationID;
    this.frm.TicketNo = this.TicketNo;
    this.frm.Source = $("#Source").val();
    this.frm.Destination = $("#Destination").val();
    this.frm.PassengerList = [];
    this.frm.Email = $("#txtEmail").val();
    this.frm.Name = $("#0_Name").val();
    this.frm.MobileNo = $("#MobileNo").val();
    this.frm.MobileNo1 = $("#MobileNo1").val();
    this.frm.JourneyDate = this.JournyDate;
    this.frm.MobileCountryCode = $("#MobileCountryCode").val();
    this.frm.RouteID = this.RouteID;
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
this.storage.set('amount',this.TotalFare*100);
this.storage.set('UName',$("#0_Name").val());
this.storage.set('UEmail',$("#txtEmail").val());
this.storage.set('UMobile',$("#MobileNo").val());

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

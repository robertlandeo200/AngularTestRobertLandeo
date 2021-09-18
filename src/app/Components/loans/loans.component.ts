import { formatDate } from '@angular/common';
import { ParsedHostBindings } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Loans } from 'src/app/Models/Loans';
import { ClientService } from 'src/app/Services/client.service';
import { LoansService } from 'src/app/Services/loans.service';

@Component({
  selector: 'app-loans',
  templateUrl: './loans.component.html',
  styleUrls: ['./loans.component.scss']
})
export class LoansComponent implements OnInit {
  public keyword = 't_ClientName';
  public dataClient: any[] = [];
  listLoans: any[] = [ ];
  task = 'Add'
  clientName = ''
  idClient = 0;
  id = 0;
  formLoan: FormGroup;
  constructor(private fb: FormBuilder, private toastr: ToastrService, private _clientService: ClientService , private _loansService: LoansService) {
    this.formLoan=this.fb.group({
      txtClientName: [""],
      txtAmount: [""],
      txtDateRequest: [{value:"", disabled:true}]
    })
   }

  ngOnInit(): void {
    this.getClients();
    this.getLoans()
  }
  validateNumber(event: any){
    var charCode = (event.which) ? event.which : event.keyCode;
    if (charCode != 46 && charCode > 31
      && (charCode < 48 || charCode > 57)) {
      event.preventDefault();
      return false;
    }
    return true;
  }
  selectClient(item:any) {
    this._loansService.getListLoansxIdClient(item.iD_Client).subscribe(data => {
      this.listLoans = data.ltLoans;
    }, error => {
      console.log(error);
    });
  }
  selectClientLoan(item:any) {
    this.idClient = item.iD_Client;
    this.clientName = item.t_ClientName;
  }
  getClients(){
    this._clientService.getListClient().subscribe(data => {
      this.dataClient = data.ltClient;
    }, error => {
      console.log(error);
    });
  }

  getLoans(){
    this._loansService.getListLoans().subscribe(data => {
      this.listLoans = data.ltLoans;
    }, error => {
      console.log(error);
    });
  }
  AddNewLoan(){
    var currentDate = new Date();
    var date = formatDate(currentDate, 'yyyy/MM/dd', 'en').split("/", 3);
    const dateRequest: any ={
      year: parseInt(date[0]),
      month: parseInt(date[1]),
      day: parseInt(date[2])
    }
    this.formLoan.reset();
    this.id = 0;
    this.idClient = 0;
    this.clientName = "";
    this.formLoan.patchValue({
      txtClientName: this.clientName,
      txtDateRequest: dateRequest
    })
  }
  addLoan(){    
    if(this.idClient == 0 || (this.formLoan.get("txtAmount")?.value == null || this.formLoan.get("txtAmount")?.value == "")){
      this.toastr.error('You have to complete all text boxes!', 'Message:');
    }else{
      var oLoan = new Loans();

      var date = this.formLoan.get("txtDateRequest")?.value
      var dateRequest = date.year + '-' + date.month + '-' + date.day
      oLoan.ID_Request_Loans = this.id;
      oLoan.ID_Client = this.idClient;
      oLoan.D_Date_Request = dateRequest,
      oLoan.N_Request_Amount = parseFloat(this.formLoan.get("txtAmount")?.value)
  
      console.log(oLoan);
  
    if(this.id == 0){
      this._loansService.SaveLoans(oLoan).subscribe(data => {
        this.toastr.success('Loan was created successfully!', 'Message:');
        this.getLoans();
        this.idClient = 0;
        this.formLoan.reset();
        this.task = 'Add';
      }, error =>{
        console.log(error);
      })
    }else{
        this._loansService.EditLoans(oLoan).subscribe(data => {
        this.toastr.success('Loan was edited successfully!', 'Message:');
        this.getLoans();
        this.id = 0;
        this.idClient = 0;
        this.task = 'Add';
        this.formLoan.reset(); 
      }, error =>{
        console.log(error);
      })
    }
    }
}
getSelectedLoan(getLoan: any){
  this.task = 'Edit';
  this.id = getLoan.iD_Request_Loans;
  this.idClient = getLoan.iD_Client;
  var date = getLoan.d_Date_Request.split("/", 3);
  const dateRequest: any ={
    year: parseInt(date[2]),
    month: parseInt(date[1]),
    day: parseInt(date[0])
  }
  this.formLoan.patchValue({
    txtClientName: getLoan.t_ClientName,
    txtAmount: getLoan.n_Request_Amount,
    txtDateRequest: dateRequest
  })
}
clearClient(){
  this.idClient = 0;
}
deleteLoan(id: number){
  this._loansService.DeleteLoans(id).subscribe(data => {
    this.toastr.success('Loan was deleted successfully!', 'Message:');
    this.getLoans();
  }, error =>{
    console.log(error);
  })
}

}

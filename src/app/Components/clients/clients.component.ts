import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Client } from 'src/app/Models/clients';
import { ClientService } from 'src/app/Services/client.service';
import { ToastrService } from 'ngx-toastr';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styleUrls: [
    './clients.component.scss',
    './sidebar.scss'
  ]
})
export class ClientsComponent implements OnInit {
  listClient: any[] = [ ];
  task = 'Add'
  clientName = "";
  id = 0;
  formClient: FormGroup;
  formClientSearch: FormGroup
  mindate: any;
  maxdate: any;

  constructor(private fb: FormBuilder, private toastr: ToastrService, private _clientService: ClientService) {
    this.formClient=this.fb.group({
      txtClientName: ["", Validators.required],
      txtBirthdate: ["", Validators.required],
    })
    this.formClientSearch=this.fb.group({
      txtSearch: [""],
    })
   }

  ngOnInit(): void {
    this.configDate();
    this.getClients();
  }
  onChangeSearch(){
    var filter = this.formClientSearch.get("txtSearch")?.value;
    if(filter == ""){
      this.getClients();
    }else{
      this._clientService.getListClientxName(filter).subscribe(data => {
        this.listClient = data.ltClient;
      }, error => {
        console.log(error);
      });
    }
  }
  configDate(){
    var currentDate = new Date();
    var date = formatDate(currentDate, 'yyyy/MM/dd', 'en').split("/", 3);
    const getmindate: any ={
      year: parseInt(date[0]) - 100,
      month: parseInt(date[1]),
      day: parseInt(date[2])
    }
    const getmaxdate: any ={
      year: parseInt(date[0]) - 18,
      month: parseInt(date[1]),
      day: parseInt(date[2])
    }
    this.mindate = getmindate;
    this.maxdate = getmaxdate;
  }
  getClients(){
    this._clientService.getListClient().subscribe(data => {
      this.listClient = data.ltClient;
    }, error => {
      console.log(error);
    });
  }
  
  getClientsxName(){
    this._clientService.getListClientxName(this.clientName).subscribe(data => {
      this.listClient = data.ltClient;
    }, error => {
      console.log(error);
    });
  }
  AddNewClient(){
    this.formClient.reset();
  }
  addClient(){    
    var date = this.formClient.get("txtBirthdate")?.value
    if((this.formClient.get("txtClientName")?.value == null || this.formClient.get("txtClientName")?.value == "") || (date == "" || date == null)){
      this.toastr.error('You have to complete all text boxes!', 'Message:');
    }else{
      var oClient = new Client();

      var birthdate = date.year + '-' + date.month + '-' + date.day
      oClient.ID_Client = this.id;
      oClient.T_ClientName = this.formClient.get("txtClientName")?.value,
      oClient.D_Birthdate = birthdate
  
    if(this.id == 0){
      this._clientService.SaveClient(oClient).subscribe(data => {
        this.toastr.success('Client ' + oClient.T_ClientName + ' was created successfully!', 'Message:');
        this.getClients();
        this.formClient.reset();
        this.task = 'Add';
      }, error =>{
        console.log(error);
      })
    }else{
        this._clientService.EditClient(oClient).subscribe(data => {
        this.toastr.success('Client was edited successfully!', 'Message:');
        this.getClients();
        this.id = 0;
        this.task = 'Add';
        this.formClient.reset(); 
      }, error =>{
        console.log(error);
      })
    }
    }
}

getSelectedClient(getClient: any){
  this.task = 'Edit';
  this.id = getClient.iD_Client;
  var date = getClient.d_Birthdate.split("/", 3);
  const birthdate: any ={
    year: parseInt(date[2]),
    month: parseInt(date[1]),
    day: parseInt(date[0])
  }
  console.log(birthdate)
  this.formClient.patchValue({
    txtClientName: getClient.t_ClientName,
    txtBirthdate: birthdate
  })
}

deleteClient(id: number){
  this._clientService.DeleteClient(id).subscribe(data => {
    this.toastr.success('Client was deleted successfully!', 'Message:');
    this.getClients();
  }, error =>{
    console.log(error);
  })
}

}

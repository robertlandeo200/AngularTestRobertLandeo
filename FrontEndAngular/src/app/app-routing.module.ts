import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientsComponent } from './Components/clients/clients.component';
import { LoansComponent } from './Components/loans/loans.component';

const routes: Routes = [
  {path: 'client', component:ClientsComponent},
  {path: 'loan', component:LoansComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

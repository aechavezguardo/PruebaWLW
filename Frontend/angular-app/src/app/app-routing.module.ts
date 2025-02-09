import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AuthGuard } from './auth.guard';
import { InvoiceComponent } from './invoice/invoice.component';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },  
  { path: 'login', component: LoginComponent },          
  {
    path: 'dashboard',
    component: DashboardComponent,
    canActivate: [AuthGuard],  
  },
  { path: '**', redirectTo: '/login' } ,
  { path: 'crear-factura', component: InvoiceComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
import { Routes } from '@angular/router';
import { EmployeeListComponent } from './features/employees/employee-list/employee-list.component';
import { EditEmployeeComponent } from './features/employees/edit-employee/edit-employee.component';
import { AddEmployeeComponent } from './features/employees/add-employee/add-employee.component';

export const routes: Routes = [
    { path: 'employees', component: EmployeeListComponent },
    { path: '', redirectTo: 'employees', pathMatch: 'full' },
    { path: 'employee/add', component: AddEmployeeComponent },
    { path: 'employee/:id', component: EditEmployeeComponent }
];

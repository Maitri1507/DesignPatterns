import { Component, OnInit } from '@angular/core';
import { Employee } from '../../../models/employee.model';
import { EmployeeService } from '../../../services/employee.service';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [CommonModule,RouterModule, FormsModule],
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.scss'
})
export class EmployeeListComponent implements OnInit {

  employees:Employee[] = []; // this is an array of employees that will be displayed in the table
  searchTerm:string = "";
  filteredEmployees:Employee[] = []; // this is an array of employees that will be displayed in the table after filtering
  sortDirection: boolean = true; // true = ASC, false = DESC

  
  constructor(private employeeService: EmployeeService) { }

  ngOnInit():void{
    this.loadEmployees();
  }


  loadEmployees():void{
    
    this.employeeService.getEmployees().subscribe({
      next: (data) => {this.employees = data;
         this.filteredEmployees = data},
      error: (err) => console.error("Error loading employees ",err)
    });
  }


sortBy(column: keyof Employee): void {
  this.filteredEmployees = [...this.filteredEmployees].sort((a, b) => {
    if (a[column] < b[column]) return this.sortDirection ? -1 : 1;
    if (a[column] > b[column]) return this.sortDirection ? 1 : -1;
    return 0;
  });

  this.sortDirection = !this.sortDirection; // toggle direction
}


  filterEmployees():void{
    const text = this.searchTerm.toLowerCase();
    this.filteredEmployees = this.employees.filter(emp =>emp.name.toLowerCase().includes(text));
  }

  deleteEmployee(id: number): void {
  if (!confirm("Are you sure you want to delete this employee?")) {
    return;
  }

  this.employeeService.deleteEmployee(id).subscribe({
    next: () => {
      // Refresh the list after delete
      this.loadEmployees();
    },
    error: (err: any) => console.error("Error deleting employee", err)
  });
}

}

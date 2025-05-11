import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { StudentService } from '../../students/student.service';
import { Student } from '../../models/student.model';
import { inject } from '@angular/core';
import { MatTableModule } from '@angular/material/table';  
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginatorModule } from '@angular/material/paginator';
import { CommonModule } from '@angular/common';
import { MatChipsModule } from '@angular/material/chips';
import { MatFormFieldModule } from '@angular/material/form-field';


@Component({
  selector: 'app-student-list',
  standalone: true,
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.scss'],
  imports: [
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatPaginatorModule,
    CommonModule,
    MatChipsModule,
    MatFormFieldModule,
    
  ],
})
export class StudentListComponent {
  students: Student[] = [];
   displayedColumns: string[] = ['fullName', 'className', 'isVaccinated', 'actions'];
  private studentService = inject(StudentService);
  public router = inject(Router);

  constructor() {
  }

  ngOnInit(): void {
    this.loadStudents();
  }

  loadStudents(): void {
    this.studentService.getAll().subscribe(students => {
      this.students = students;
    });
  }

  onEdit(studentId: number): void {
    this.router.navigate(['/students', studentId, 'edit']);
  }

  onDelete(studentId: number): void {
    if (confirm('Are you sure you want to delete this student?')) {
    this.studentService.delete(studentId).subscribe(() => {
      this.loadStudents();
    });
    }
  }



}

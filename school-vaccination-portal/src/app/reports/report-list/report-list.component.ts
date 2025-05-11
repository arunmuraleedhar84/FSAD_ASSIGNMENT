import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { HttpClient } from '@angular/common/http';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';


@Component({
  selector: 'app-report-list',
  standalone: true,
  imports: [CommonModule, MatTableModule, MatFormFieldModule, MatInputModule, MatPaginatorModule, ReactiveFormsModule,MatIconModule],
  templateUrl: './report-list.component.html',
  styleUrl: './report-list.component.scss'
})
export class ReportListComponent {

 dataSource = new MatTableDataSource<any>([]); 
  displayedColumns: string[] = ['studentName', 'class', 'guard', 'vaccineName', 'vaccinationDate', 'vaccinated'];
  filter = new FormControl('');

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.fetchData();
    
  }

  fetchData(): void {
    this.http.get<any[]>('https://localhost:7281/api/Reports/vaccination').subscribe(data => {
      this.dataSource.data = data;
      // Apply initial filter if there's a value
      if (this.filter.value) {
        this.dataSource.filter = this.filter.value.toLowerCase();
      }
    });
  }

  get filteredData() {
    return this.dataSource.filteredData;
  }

  applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
   exportCSV(): void {
    const headers = this.displayedColumns.join(',');
    const rows = this.filteredData.map(row =>
      this.displayedColumns.map(col => `"${row[col] ?? ''}"`).join(',')
    );
    const csvContent = [headers, ...rows].join('\n');
    const blob = new Blob([csvContent], { type: 'text/csv' });
    const link = document.createElement('a');
    link.href = URL.createObjectURL(blob);
    link.download = 'vaccination-report.csv';
    link.click();
  }

  // exportPDF(): void {
  //   import('jspdf').then(jsPDF => {
  //     import('jspdf-autotable').then(() => {
  //       const doc = new jsPDF.default();
  //       doc.autoTable({
  //         head: [this.displayedColumns],
  //         body: this.filteredData.map(row => this.displayedColumns.map(col => row[col] ?? ''))
  //       });
  //       doc.save('vaccination-report.pdf');
  //     });
  //   });
  // }
}

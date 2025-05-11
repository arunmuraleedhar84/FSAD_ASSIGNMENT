import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';


@Component({
  selector: 'app-student-bulk-upload',
  standalone: true,
  imports: [    
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatCardModule
  ],
  templateUrl: './student-bulk-upload.component.html',
  styleUrl: './student-bulk-upload.component.scss'
})


export class StudentBulkUploadComponent {
  selectedFile: File | null = null;

  constructor(private http: HttpClient) {}

  onFileSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      this.selectedFile = input.files[0];
    }
  }

 

  upload(): void {
    if (!this.selectedFile) return;
  
    const formData = new FormData();
    formData.append('StudentFile', this.selectedFile, this.selectedFile.name);
    this.http.post('https://localhost:7281/api/Students/bulk-upload', formData).subscribe({
      next: () => alert('Upload successful'),
      error: (error) => {
        console.error('Upload failed:', error);
        alert('Upload failed: ' + (error?.error?.message || 'Please try again.'));
      }
    });

    this.selectedFile = null;
    
  }
}

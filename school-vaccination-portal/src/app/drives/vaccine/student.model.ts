export interface Student {
  id: number;
  fullName: string;
  className: string;
  section: string;
  guardianName: string;
  createdTime: Date;
  updatedTime?: Date;
}
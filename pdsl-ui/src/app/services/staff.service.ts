import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { staff } from './staff.data';
import { Staff } from './staff.interface';

@Injectable({
    providedIn: 'root',
})
export class StaffService {

    private staff: Staff[] = staff;

    getAllStaff(): Observable<Staff> {
        return new Observable<Staff>(observer => {
            staff.forEach(staff => {
                observer.next(staff);
            });
        })
    }

    getStaffById(id: number): Observable<Staff> {
        return new Observable<Staff>(observer => observer.next(this.staff.filter(s => s.id === id)[0]));
    }
}

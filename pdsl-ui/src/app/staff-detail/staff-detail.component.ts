import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { Staff } from '../services/staff.model';
import { StaffService } from '../services/staff.service';

@Component({
    selector: 'pdsl-staff-detail',
    templateUrl: './staff-detail.component.html',
    styleUrls: ['./staff-detail.component.css'],
})
export class StaffDetailComponent implements OnInit {

    staff: Staff;
    errorMessage: string = '';

    constructor(private activatedRoute: ActivatedRoute, private staffService: StaffService, private titleService: Title) {
        this.staff = {
            id: 0,
            name: '',
            title: '',
            profileImagePath: ''
        };
    }

    ngOnInit(): void {
        const idText: string = this.activatedRoute.snapshot.paramMap.get('id') ?? '';
        if(!idText) {
            this.errorMessage = 'Invalid route';
            return;
        }

        const id: number = +idText;
        this.staffService.getStaffById(id)
            .subscribe({
                next: staff => this.staff = staff,
                error: error => this.errorMessage = error
            });
        this.titleService.setTitle(`PDSL | About ${this.staff.name}`);
    }
}

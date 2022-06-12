import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'pdsl-applications',
  templateUrl: './applications.component.html',
  styleUrls: ['./applications.component.css']
})
export class ApplicationsComponent implements OnInit {

  constructor(private titleService: Title) {
        this.titleService.setTitle('PDSL | Application');
   }

  ngOnInit(): void {
  }

}

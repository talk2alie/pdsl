import { Component } from "@angular/core";

@Component({
    selector: 'pdsl-footer',
    templateUrl: './footer.component.html',
    styleUrls: ['./footer.component.css']
})
export class FooterComponent {
    appYear: number = new Date().getFullYear();
}
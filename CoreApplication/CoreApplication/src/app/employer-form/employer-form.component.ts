import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http'
import { ClientApplication } from '../client-application';
import { ClientQuestion} from '../client-question';

@Component({
    selector: 'app-employer-form',
    templateUrl: './employer-form.component.html',
    styleUrls: ['./employer-form.component.css']
})
export class EmployerFormComponent implements OnInit {
    clientApplications: ClientApplication[] = [];

    constructor(private _httpService: Http) { }

    ngOnInit() {
        this._httpService.get('/api/applications').subscribe(values => {
            let json = values.json();
            for (var i = 0; i < json.length; i++) {
                let questions = [];
                for (var j = 0; j < json[i]['questions'].length; j++) {
                    questions.push(new ClientQuestion(json[i]['questions'][j]['answerId'], json[i]['questions'][j]['userAnswer']));
                }
                this.clientApplications.push(new ClientApplication(json[i].name, questions));
            }
        });
    }

}

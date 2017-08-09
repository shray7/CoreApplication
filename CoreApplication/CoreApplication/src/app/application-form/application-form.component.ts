import { Component, OnInit, Input } from '@angular/core';
import { Http } from '@angular/http'
import { Question } from '../question';
import { Answer } from '../answer';

@Component({
    selector: 'app-application-form',
    templateUrl: './application-form.component.html',
    styleUrls: ['./application-form.component.css']
})
export class ApplicationFormComponent implements OnInit {
    @Input() questions: Question[] = [];
    @Input() name: string;
    constructor(private _httpService: Http) { }
    
    ngOnInit() {
        this._httpService.get('/api/questions').subscribe(values => {
            let json = values.json();
            for (var i = 0; i < json.length; i++) {
                let question = new Question(json[i].questionId, json[i].questionDescription, json[i].answer, "");
                this.questions.push(question);
            }
        });
    }

    onSubmit() {
        console.log(this.questions);
        let answers = [];
        for (let entry of this.questions) {
            let answer = new Answer(entry.questionId, entry.userAnswer, entry.userAnswer.toUpperCase() == entry.answer.toUpperCase(), this.name);
            answers.push(answer);
        }
        this._httpService.post('/api/answers', answers, null).subscribe();
    }

}

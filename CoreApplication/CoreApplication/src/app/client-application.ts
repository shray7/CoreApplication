import { ClientQuestion } from './client-question';
export class ClientApplication {
    constructor(public name: string, public clientQuestions: ClientQuestion[]) { }
}

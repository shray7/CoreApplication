import { CoreApplicationPage } from './app.po';

describe('core-application App', () => {
  let page: CoreApplicationPage;

  beforeEach(() => {
    page = new CoreApplicationPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});

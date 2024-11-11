import { TestBed } from '@angular/core/testing';

import { SmileService } from './smile.service';

describe('SmileService', () => {
  let service: SmileService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SmileService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

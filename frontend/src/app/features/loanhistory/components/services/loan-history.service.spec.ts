import { TestBed } from '@angular/core/testing';

import { LoanHistoryService } from './loan-history.service';

describe('LoanHistoryService', () => {
  let service: LoanHistoryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LoanHistoryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

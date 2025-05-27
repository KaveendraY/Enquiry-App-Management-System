import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MasterService } from '../../service/master.service';
import { Observable } from 'rxjs';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-new-enquiry',
  standalone: true,
  imports: [FormsModule,AsyncPipe],
  templateUrl: './new-enquiry.component.html',
  styleUrl: './new-enquiry.component.css',
})
export class NewEnquiryComponent {
  newEnquiryObj: any = {
    enquiryId: 0,
    enquiryTypeId: 0,
    enquiryStatusId: 0,
    customerName: '',
    mobileNo: '',
    email: '',
    message: '',
    createdDate: new Date(),
    resolution: '',
  };
  masterSrv = inject(MasterService);

  typeList: Observable<any> = new Observable<any>();
  statusList: Observable<any> = new Observable<any>();

  constructor(){
    this.typeList = this.masterSrv.getTypes();
    this.statusList = this.masterSrv.getStatus();
  }

  onSave() {
    debugger;
    this.masterSrv.createEnquiry(this.newEnquiryObj).subscribe(
      (res: any) => {
        debugger;
      },
      (error) => {
        debugger;
      }
    );
  }
}

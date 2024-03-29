import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { ApiServiceService } from 'src/app/api-service.service';

@Component({
  selector: 'app-wh-profile',
  templateUrl: './wh-profile.component.html',
  styleUrls: ['./wh-profile.component.scss']
})
export class WhProfileComponent implements OnInit {


  getProfileUrl : string = 'https://localhost:44366/api/UserLogin/getProfiles';
  editProfilrUrl : string = 'https://localhost:44366/api/UserLogin/editProfiles';
  profile : any;
  userProfileID !: number;
  greeting !: string
  confirmBtn : boolean = false;
  editProfile : any | undefined;
  readonly : boolean = true;

  constructor(
    private apiService : ApiServiceService,
    private fb : FormBuilder,
    private spinnerService : NgxSpinnerService
  ) { }

  ngOnInit(): void {
    this.userProfileID = Number(localStorage.getItem('userID'));

    this.editProfile = this.fb.group({
      ID : this.userProfileID,
      LoginID : [''],
      EmailID : [''],
      FirstName : [''],
      LastName : [''],
      PhoneNumber : ['']
    });

    this.apiService.getMethod(`${this.getProfileUrl}/${this.userProfileID}`).subscribe((e : any) => {
      this.profile = e[0];
      this.editProfile.patchValue({
        LoginID : this.profile.LoginID,
        EmailID : this.profile.EmailID,
        FirstName : this.profile.FirstName,
        LastName : this.profile.LastName,
        PhoneNumber : this.profile.PhoneNumber
      })
    });
    
  }

  onClickSave(){
    this.confirmBtn = false;
    this.readonly = true;
    this.spinnerService.show()
    console.log(this.editProfile.value)
    this.apiService.postMethod(this.editProfilrUrl, this.editProfile.value).subscribe((e) => {
      setTimeout(() => {
        this.ngOnInit();
        this.spinnerService.hide()
      }, 1500)
    })
  }

  onClickEdit(){
    this.confirmBtn = true;
    this.readonly = false;
  }

}

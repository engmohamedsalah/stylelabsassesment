import { InMemoryDbService } from 'angular-in-memory-web-api';

export class InMemoryDataService implements InMemoryDbService {
  createDb() {
    const assets= [
      { AssetId: '51df6a98-614e-40ef-8885-95ae50940058', FileName: 'ElitProin.aam',MimeType: 'application/x-authorware-map', CreatedBy: 'sblack0', Email: 'jmitchell0@huffingtonpost.com',Country:'United States',Description:'Maecenas ut massa quis augue luctus tincidunt. Nulla mollis molestie lorem. Quisque ut erat.'},
      { AssetId: '279899c1-bc63-495c-94c5-57f25c881ed2', FileName: 'MusVivamusVestibulum.xla',MimeType: 'application/x-excel', CreatedBy: 'iadams1', Email: 'rhenry1@xrea.com',Country:'Canada',Description:'Curabitur in libero ut massa volutpat convallis. Morbi odio odio, elementum eu, interdum eu, tincidunt in, leo. Maecenas pulvinar lobortis est.'},
      { AssetId: '3060b1db-9a0a-4046-b10a-b90a0c440070', FileName: 'NullaUltrices.sit',MimeType: 'application/x-sit', CreatedBy: 'jmatthews2', Email: 'jadams2@ft.com',Country:'Japan',Description:'Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa. Donec dapibus. Duis at velit eu est congue elementum.'},
      { AssetId: '7ef8ddf4-0b60-43e6-9e17-21029da02c69', FileName: 'Eros.tsv',MimeType: 'text/tab-separated-values', CreatedBy: 'dadams3', Email: 'jmoreno3@joomla.org',Country:'Serbia',Description:'Curabitur in libero ut massa volutpat convallis. Morbi odio odio, elementum eu, interdum eu, tincidunt in, leo. Maecenas pulvinar lobortis est.'},
      { AssetId: '588610a3-b546-4c2e-822d-c822ba20a775', FileName: 'BlanditNam.aim',MimeType: 'application/x-aim', CreatedBy: 'dpierce4', Email: 'aortiz4@devhub.com',Country:'United States',Description:'In congue. Etiam justo. Etiam pretium iaculis justo.'},
      { AssetId: '3de294a8-8f13-4f86-b447-92e8fd79277d', FileName: 'NecCondimentumNeque.jpe',MimeType: 'image/jpeg', CreatedBy: 'pyoung5', Email: 'ckim5@ft.com',Country:'Romania',Description:'Fusce posuere felis sed lacus. Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl. Nunc rhoncus dui vel sem.'},
      { AssetId: '209bf3d7-e792-4f3f-98e8-240efcf81e31', FileName: 'DuisMattisEgestas.gif',MimeType: 'image/gif', CreatedBy: 'ldaniels6', Email: 'mreid6@seattletimes.com',Country:'Belgium',Description:'Curabitur in libero ut massa volutpat convallis. Morbi odio odio, elementum eu, interdum eu, tincidunt in, leo. Maecenas pulvinar lobortis est.'},
      { AssetId: '975eaf96-dd9f-4534-89a6-0ebabb730aa0', FileName: 'HacHabitassePlatea.arj',MimeType: 'application/octet-stream', CreatedBy: 'smorales7', Email: 'jgarrett7@geocities.jp',Country:'Spain',Description:'In congue. Etiam justo. Etiam pretium iaculis justo.'},
      { AssetId: '5a8393df-d4aa-4734-8df4-10a611cd5cc7', FileName: 'NullaSuscipit.rt',MimeType: 'text/vnd.rn-realtext', CreatedBy: 'jschmidt8', Email: 'rbowman8@prnewswire.com',Country:'United States',Description:'Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa. Donec dapibus. Duis at velit eu est congue elementum.'},
      { AssetId: 'f41dd5e6-8833-4b22-8e33-edcb024c4c1f', FileName: 'Odio.mime',MimeType: 'message/rfc822', CreatedBy: 'cholmes9', Email: 'rjones9@accuweather.com',Country:'Nigeria',Description:'Fusce posuere felis sed lacus. Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl. Nunc rhoncus dui vel sem.'},
      { AssetId: '74d04563-f253-4fcb-8caa-dfb2e1bba7ed', FileName: 'SuspendissePotentiCras.list',MimeType: 'text/plain', CreatedBy: 'tlawsona', Email: 'sstevensa@ft.com',Country:'United States',Description:'Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem.'},
      { AssetId: 'b5e8cd08-9c37-4568-8b6c-565ed17b2707', FileName: 'Neque.shtml',MimeType: 'text/x-server-parsed-html', CreatedBy: 'jmoralesb', Email: 'wberryb@berkeley.edu',Country:'East Timor',Description:'Morbi non lectus. Aliquam sit amet diam in magna bibendum imperdiet. Nullam orci pede, venenatis non, sodales sed, tincidunt eu, felis.'},
      { AssetId: '23b13a2f-4843-441a-b77e-af119ca1bb2e', FileName: 'FelisUt.wav',MimeType: 'audio/x-wav', CreatedBy: 'cpowellc', Email: 'sfernandezc@tiny.cc',Country:'Malaysia',Description:'Cras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit. Vivamus vel nulla eget eros elementum pellentesque.'},
      { AssetId: 'a4bfebd2-8266-4e7a-96a6-7e34acdb5f75', FileName: 'InTemporTurpis.dxr',MimeType: 'application/x-director', CreatedBy: 'fjacksond', Email: 'jjenkinsd@about.com',Country:'Japan',Description:'Proin leo odio, porttitor id, consequat in, consequat ut, nulla. Sed accumsan felis. Ut at dolor quis odio consequat varius.'},
      { AssetId: '55e3000e-e672-4ba3-9dcf-f8936e174859', FileName: 'VulputateNonummy.dcr',MimeType: 'application/x-director', CreatedBy: 'kmartine', Email: 'rreede@networkadvertising.org',Country:'China',Description:'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin risus. Praesent lectus.'},
      { AssetId: 'ed6bf8f3-117b-444a-bb77-a4e776be91df', FileName: 'Urna.bin',MimeType: 'application/mac-binary', CreatedBy: 'khicksf', Email: 'rhillf@elpais.com',Country:'Kuwait',Description:'Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem.'},
      
    ];
    return {assets};
  }
}


/*
Copyright 2017-2018 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/
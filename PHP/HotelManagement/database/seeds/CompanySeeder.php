<?php

use Illuminate\Database\Seeder;

class CompanySeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        $items = [
            [
              'name' => 'SIT Tour',
              'address' => '433 Yarrow Street',
              'phone' => '0217495243',
              'details' => 'SIT great agency.'
            ],
            [
              'name' => 'Invercargill Tour',
              'address' => '323 Dee Street',
              'phone' => '0267826434',
              'details' => 'Invercargill tours.'
            ],
           
          ];
          foreach($items as $item) {
            App\Company::create($item);
          }
    }
}

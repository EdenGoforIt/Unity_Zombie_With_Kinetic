<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreatePaymentsTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
  
    public function up()
    {
        Schema::create('payments', function (Blueprint $table) {
            $table->bigIncrements('id');

            $table->unsignedBigInteger('customer_id');
            $table->foreign('customer_id')->references('id')->on('customers');

            $table->unsignedBigInteger('booking_id');
            

            $table->string('card_holder');
            $table->string('card_number');
            $table->string('expiration_date');
            $table->enum('payment_type',['CreditCard','Cash','Debit','Voucher','EFTPOS']);
            $table->float('amount',8,2);
            $table->float('charge_back',8,2);
            $table->date('payment_date');
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('payments');
    }
}

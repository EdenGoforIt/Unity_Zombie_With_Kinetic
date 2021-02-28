<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Payment extends Model
{
    protected $fillable =  ['customer_id', 'booking_id', 'card_holder', 'card_number', 'expiration_date', 'payment_type', 'amount', 'payment_date', 'charge_back'];

    public function customer()
    {
        return $this->belongsTo(Customer::class);
    }
}

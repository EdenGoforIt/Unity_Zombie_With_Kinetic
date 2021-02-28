@extends('layouts.app')

@section('content')
<h3 class="page-title">Payment</h3>
{!! Form::open(['method' => 'POST', 'route' => ['admin.payments.store']]) !!}

<div class="panel panel-default">
    <div class="panel-heading">
        @lang('quickadmin.qa_create')
    </div>
    <!-- ['customer_id','room_id','card_holder','card_number','expiration_date','payment_type','amount','payment_date']; -->

    <div class="panel-body">
        <div class="row">
            <div class="col-xs-12 form-group">
                {!! Form::label('customer_id', trans('Customer').'', ['class' => 'control-label']) !!}
                {!! Form::select('customer_id', $customers, old('customer_id'), ['class' => 'form-control select2']) !!}
                <p class="help-block"></p>
                @if($errors->has('customer_id'))
                <p class="help-block">
                    {{ $errors->first('customer_id') }}
                </p>
                @endif
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12 form-group">
                {!! Form::label('booking_id', trans('Reference Number').'', ['class' => 'control-label']) !!}
                {!! Form::select('booking_id', $bookings, old('booking_id'), ['class' => 'form-control select2']) !!}
                <p class="help-block"></p>
                @if($errors->has('booking_id'))
                <p class="help-block">
                    {{ $errors->first('booking_id') }}
                </p>
                @endif
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12 form-group">
                {!! Form::label('card_holder', trans('Card Holder').'*', ['class' => 'control-label']) !!}
                {!! Form::text('card_holder', old('card_holder'), ['class' => 'form-control', 'placeholder' => '', 'required' => '']) !!}
                <p class="help-block"></p>
                @if($errors->has('card_holder'))
                <p class="help-block">
                    {{ $errors->first('card_holder') }}
                </p>
                @endif
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12 form-group">
                {!! Form::label('card_number', trans('Card Number').'*', ['class' => 'control-label']) !!}
                {!! Form::text('card_number', old('card_number'), ['class' => 'form-control', 'placeholder' => '', 'required' => '']) !!}
                <p class="help-block"></p>
                @if($errors->has('card_number'))
                <p class="help-block">
                    {{ $errors->first('card_number') }}
                </p>
                @endif
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12 form-group">
                {!! Form::label('expiration_date', trans('Expiration Date').'*', ['class' => 'control-label']) !!}
                {!! Form::text('expiration_date', old('expiration_date'), ['class' => 'form-control', 'placeholder' => '', 'required' => '']) !!}
                <p class="help-block"></p>
                @if($errors->has('expiration_date'))
                <p class="help-block">
                    {{ $errors->first('expiration_date') }}
                </p>
                @endif
            </div>
            
        </div>
        <div class="row">
            <div class="col-xs-12 form-group">
                <!-- CreditCard','Cash','Debit','Voucher','EFTPOS' -->
                <label name="payment_type" for="sel1">Select Payment Type*</label>
                <select class="form-control" id="sel1" name="payment_type">
                    <option value="1">Credit Card</option>
                    <option value="2">Cash</option>
                    <option value="3">Debit Card</option>
                    <option value="4">Voucher</option>
                    <option value="5">EFTPOS</option>
                </select>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12 form-group">
                {!! Form::label('payment_date', trans('Payment Date').'*', ['class' => 'control-label']) !!}
                {!! Form::text('payment_date', old('payment_date'), ['class' => 'form-control datetimepicker', 'placeholder' => '', 'required' => '']) !!}
                <p class="help-block"></p>
                @if($errors->has('payment_date'))
                <p class="help-block">
                    {{ $errors->first('payment_date') }}
                </p>
                @endif
            </div>
        </div>
        
        <div class="row">
            <div class="col-xs-12 form-group">
                {!! Form::label('charge_back', trans('Charge Back').'*', ['class' => 'control-label']) !!}
                {!! Form::text('charge_back', old('charge_back'), ['class' => 'form-control', 'placeholder' => '', 'required' => '']) !!}
                <p class="help-block"></p>
                @if($errors->has('charge_back'))
                <p class="help-block">
                    {{ $errors->first('charge_back') }}
                </p>
                @endif
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12 form-group">
                {!! Form::label('amount', trans('Amount').'*', ['class' => 'control-label']) !!}
                {!! Form::text('amount', old('amount'), ['class' => 'form-control', 'placeholder' => '', 'required' => '']) !!}
                <p class="help-block"></p>
                @if($errors->has('amount'))
                <p class="help-block">
                    {{ $errors->first('amount') }}
                </p>
                @endif
            </div>
        </div>


    </div>
</div>

{!! Form::submit(trans('quickadmin.qa_save'), ['class' => 'btn btn-danger']) !!}
{!! Form::close() !!}
@stop
@section('javascript')
@parent
<script src="https://cdn.datatables.net/select/1.2.0/js/dataTables.select.min.js"></script>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.47/css/bootstrap-datetimepicker.min.css">
<script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.20.1/moment.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.47/js/bootstrap-datetimepicker.min.js"></script>
<script>
    $('.datetimepicker').datetimepicker({
        format: "YYYY-MM-DD HH:mm"
    });
</script>
@stop
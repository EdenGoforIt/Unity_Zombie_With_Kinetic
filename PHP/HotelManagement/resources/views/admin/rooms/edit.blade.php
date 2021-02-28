@extends('layouts.app')

@section('content')
    <h3 class="page-title">@lang('quickadmin.rooms.title')</h3>
    
    {!! Form::model($room, ['method' => 'PUT', 'route' => ['admin.rooms.update', $room->id]]) !!}

    <div class="panel panel-default">
        <div class="panel-heading">
            @lang('quickadmin.qa_edit')
        </div>

        <div class="panel-body">
            <div class="row">
                <div class="col-xs-12 form-group">
                    {!! Form::label('room_number', trans('quickadmin.rooms.fields.room-number').'*', ['class' => 'control-label']) !!}
                    {!! Form::text('room_number', old('room_number'), ['class' => 'form-control', 'placeholder' => '', 'required' => '']) !!}
                    <p class="help-block"></p>
                    @if($errors->has('room_number'))
                        <p class="help-block">
                            {{ $errors->first('room_number') }}
                        </p>
                    @endif
                </div>
            </div>
            <!-- <div class="row">
                <div class="col-xs-12 form-group">
                    {!! Form::label('room_status', 'Room Status', ['class' => 'control-label']) !!}
                    {!! Form::select('room_status', ['vacantClean','vacantDirty','occupiedClean','occupiedService','onMaintenance'], old('room_status'), ['class' => 'form-control select2']) !!}

                    <p class="help-block"></p>
                    @if($errors->has('room_status'))
                        <p class="help-block">
                            {{ $errors->first('room_status') }}
                        </p>
                    @endif
                </div>
            </div> -->
            <div class="row">
            <div class="col-xs-12 form-group">
                <!-- CreditCard','Cash','Debit','Voucher','EFTPOS' -->
                <label name="room_status" for="room_status">Select Room Status*</label>
                <select class="form-control" id="room_status" name="room_status">
                    <option value="1">vacantClean</option>
                    <option value="2">vacantDirty</option>
                    <option value="3">occupiedClean</option>
                    <option value="4">occupiedService</option>
                    <option value="5">onMaintenance</option>
                </select>
            </div>
        </div>
            <div class="row">
                <div class="col-xs-12 form-group">
                    {!! Form::label('floor', trans('quickadmin.rooms.fields.floor').'*', ['class' => 'control-label']) !!}
                    {!! Form::number('floor', old('floor'), ['class' => 'form-control', 'placeholder' => '', 'required' => '']) !!}
                    <p class="help-block"></p>
                    @if($errors->has('floor'))
                        <p class="help-block">
                            {{ $errors->first('floor') }}
                        </p>
                    @endif
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 form-group">
                    {!! Form::label('description', trans('quickadmin.rooms.fields.description').'*', ['class' => 'control-label']) !!}
                    {!! Form::textarea('description', old('description'), ['class' => 'form-control ', 'placeholder' => '', 'required' => '']) !!}
                    <p class="help-block"></p>
                    @if($errors->has('description'))
                        <p class="help-block">
                            {{ $errors->first('description') }}
                        </p>
                    @endif
                </div>
            </div>
            
        </div>
    </div>

    {!! Form::submit(trans('quickadmin.qa_update'), ['class' => 'btn btn-danger']) !!}
    {!! Form::close() !!}
@stop


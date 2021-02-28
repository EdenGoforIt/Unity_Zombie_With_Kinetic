@inject('request', 'Illuminate\Http\Request')
@extends('layouts.app')

@section('content')
<h3 class="page-title">Checksheets</h3>
<!-- // ['start_time', 'end_time', 'total_cycle', 'room_id','housekeeper_id']; -->
<p>
    <a href="{{ route('admin.checksheets.create') }}" class="btn btn-success">@lang('quickadmin.qa_add_new')</a>

</p>


@can('checksheet_delete')
<p>
    <ul class="list-inline">
        <li><a href="{{ route('admin.checksheets.index') }}" style="{{ request('show_deleted') == 1 ? '' : 'font-weight: 700' }}">@lang('quickadmin.qa_all')</a></li> |
        <li><a href="{{ route('admin.checksheets.index') }}?show_deleted=1" style="{{ request('show_deleted') == 1 ? 'font-weight: 700' : '' }}">@lang('quickadmin.qa_trash')</a></li>
    </ul>
</p>
@endcan


<div class="panel panel-default">
    <div class="panel-heading">
        @lang('quickadmin.qa_list')
    </div>

    <div class="panel-body table-responsive">
        <table class="table table-bordered table-striped {{ count($checksheets) > 0 ? 'datatable' : '' }} @can('checksheet_delete') @if ( request('show_deleted') != 1 ) dt-select @endif @endcan">
            <thead>
                <tr>
                    <th style="text-align:center;"><input type="checkbox" id="select-all" /></th>
                    <!-- // ['start_time', 'end_time', 'total_cycle', 'room_id','housekeeper_id']; -->
                    <th>START TIME</th>
                    <th>END TIME</th>
                    <th>TOTAL CYCLE</th>
                    <th>ROOM</th>
                    <th>HOUSEKEEPER</th>

                    <th>&nbsp;</th>

                    <th>&nbsp;</th>

                </tr>
            </thead>

            <tbody>
                @if (count($checksheets) > 0)
                @foreach ($checksheets as $checksheet)
                <tr data-entry-id="{{ $checksheet->id }}">

                    <td></td>

                    <td field-key='start_time'>{{ $checksheet->start_time }}</td>

                    <td field-key='end_time'>{{ $checksheet->end_time }}</td>
                    <td field-key='total_cycle'>{{ $checksheet->total_cycle }}</td>
                    <td field-key='room_id'>{{ $checksheet->room_id }}</td>



                    <td field-key='housekeeper_id'>{{ $checksheet->housekeeper_id }}</td>

                    <td>

                        {!! Form::open(array(
                        'style' => 'display: inline-block;',
                        'method' => 'POST',
                        'onsubmit' => "return confirm('".trans("quickadmin.qa_are_you_sure")."');",
                        'route' => ['admin.checksheets.restore', $checksheet->id])) !!}
                        {!! Form::submit(trans('quickadmin.qa_restore'), array('class' => 'btn btn-xs btn-success')) !!}
                        {!! Form::close() !!}


                        {!! Form::open(array(
                        'style' => 'display: inline-block;',
                        'method' => 'DELETE',
                        'onsubmit' => "return confirm('".trans("quickadmin.qa_are_you_sure")."');",
                        'route' => ['admin.checksheets.perma_del', $checksheet->id])) !!}
                        {!! Form::submit(trans('quickadmin.qa_permadel'), array('class' => 'btn btn-xs btn-danger')) !!}
                        {!! Form::close() !!}

                    </td>

                    <td>

                        <a href="{{ route('admin.checksheets.show',[$checksheet->id]) }}" class="btn btn-xs btn-primary">@lang('quickadmin.qa_view')</a>


                        <a href="{{ route('admin.checksheets.edit',[$checksheet->id]) }}" class="btn btn-xs btn-info">@lang('quickadmin.qa_edit')</a>

                        {!! Form::open(array(
                        'style' => 'display: inline-block;',
                        'method' => 'DELETE',
                        'onsubmit' => "return confirm('".trans("quickadmin.qa_are_you_sure")."');",
                        'route' => ['admin.checksheets.destroy', $checksheet->id])) !!}
                        {!! Form::submit(trans('quickadmin.qa_delete'), array('class' => 'btn btn-xs btn-danger')) !!}
                        {!! Form::close() !!}

                    </td>

                </tr>
                @endforeach
                @else
                <tr>
                    <td colspan="8">@lang('quickadmin.qa_no_entries_in_table')</td>
                </tr>
                @endif
            </tbody>
        </table>
    </div>
</div>
@stop

@section('javascript')
<script>
    @can('checksheet_delete')
    @if(request('show_deleted') != 1) window.route_mass_crud_entries_destroy = '{{ route('
    admin.checksheets.mass_destroy ') }}';
    @endif
    @endcan
</script>
@endsection
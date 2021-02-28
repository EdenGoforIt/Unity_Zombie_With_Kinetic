@inject('request', 'Illuminate\Http\Request')
@extends('layouts.app')

@section('content')
<h3 class="page-title">Agency</h3>

<p>
    <a href="{{ route('admin.agencies.create') }}" class="btn btn-success">@lang('quickadmin.qa_add_new')</a>

</p>
<!-- ['name','address','phone','details']; -->


<p>
    <ul class="list-inline">
        <li><a href="{{ route('admin.agencies.index') }}" style="{{ request('show_deleted') == 1 ? '' : 'font-weight: 700' }}">@lang('quickadmin.qa_all')</a></li> |
        <li><a href="{{ route('admin.agencies.index') }}?show_deleted=1" style="{{ request('show_deleted') == 1 ? 'font-weight: 700' : '' }}">@lang('quickadmin.qa_trash')</a></li>
    </ul>
</p>



<div class="panel panel-default">
    <div class="panel-heading">
        @lang('quickadmin.qa_list')
    </div>

    <div class="panel-body table-responsive">
        <table class="table table-bordered table-striped {{ count($agencies) > 0 ? 'datatable' : '' }} @can('agency_delete') @if ( request('show_deleted') != 1 ) dt-select @endif @endcan">
            <thead>
                <tr>

                    @if ( request('show_deleted') != 1 )<th style="text-align:center;"><input type="checkbox" id="select-all" /></th>@endif

                    <th>Name</th>
                    <th>Address</th>
                    <th>Phone</th>
                    <th>Details</th>
                    @if( request('show_deleted') == 1 )
                    <th>&nbsp;</th>
                    @else
                    <th>&nbsp;</th>
                    @endif
                </tr>
            </thead>

            <tbody>
                @if (count($agencies) > 0)
                @foreach ($agencies as $agency)
                <tr data-entry-id="{{ $agency->id }}">

                    @if ( request('show_deleted') != 1 )<td></td>@endif


                    <td field-key='name'>{{ $agency->name }}</td>
                    <td field-key='address'>{{ $agency->address }}</td>
                    <td field-key='phone'>{{ $agency->phone }}</td>
                    <td field-key='details'>{{ $agency->details }}</td>

                    <!--<td>

                        {!! Form::open(array(
                        'style' => 'display: inline-block;',
                        'method' => 'POST',
                        'onsubmit' => "return confirm('".trans("quickadmin.qa_are_you_sure")."');",
                        'route' => ['admin.agencies.restore', $agency->id])) !!}
                        {!! Form::submit(trans('quickadmin.qa_restore'), array('class' => 'btn btn-xs btn-success')) !!}
                        {!! Form::close() !!}

                        {!! Form::open(array(
                        'style' => 'display: inline-block;',
                        'method' => 'DELETE',
                        'onsubmit' => "return confirm('".trans("quickadmin.qa_are_you_sure")."');",
                        'route' => ['admin.agencies.perma_del', $agency->id])) !!}
                        {!! Form::submit(trans('quickadmin.qa_permadel'), array('class' => 'btn btn-xs btn-danger')) !!}
                        {!! Form::close() !!}

                    </td>-->

                    <td>

                        <a href="{{ route('admin.agencies.show',[$agency->id]) }}" class="btn btn-xs btn-primary">@lang('quickadmin.qa_view')</a>

                        <a href="{{ route('admin.agencies.edit',[$agency->id]) }}" class="btn btn-xs btn-info">@lang('quickadmin.qa_edit')</a>

                        {!! Form::open(array(
                        'style' => 'display: inline-block;',
                        'method' => 'DELETE',
                        'onsubmit' => "return confirm('".trans("quickadmin.qa_are_you_sure")."');",
                        'route' => ['admin.agencies.destroy', $agency->id])) !!}
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
    @can('agency_delete')
    @if(request('show_deleted') != 1) window.route_mass_crud_entries_destroy = '{{ route('
    admin.agencies.mass_destroy ') }}';
    @endif
    @endcan
</script>
@endsection

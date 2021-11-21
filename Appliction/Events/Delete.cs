namespace Appliction.Events
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }
        

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
               var eventArgs = await _context.Events.FindAsync(new object[] { request.Id }, cancellationToken);
                if (eventArgs == null)
                {
                    return null;
                }

                _context.Remove(eventArgs);

                var result = await _context.SaveChangesAsync(cancellationToken) >0;

                if (!result)
                {
                    return Result<Unit>.Failure("Failed to update event.");
                }
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}

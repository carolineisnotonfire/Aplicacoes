namespace WpfAppEntity.Data
{

    using System.Data.Entity;


    public partial class BibliotecaDBContext : DbContext
    {
        public BibliotecaDBContext()
            : base("name=BibliotecaDBContext")
        {
        }

        public virtual DbSet<Autores> Autores { get; set; }
        public virtual DbSet<Editora> Editora { get; set; }
        public virtual DbSet<Generos> Generos { get; set; }
        public virtual DbSet<Livros> Livros { get; set; }
        public virtual DbSet<Locacao> Locacao { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autores>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Autores>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Autores>()
                .HasMany(e => e.Livros)
                .WithMany(e => e.Autores)
                .Map(m => m.ToTable("LivroAutor").MapLeftKey("Autor").MapRightKey("Livro"));

            modelBuilder.Entity<Editora>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Editora>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Editora>()
                .HasMany(e => e.Livros)
                .WithRequired(e => e.Editora1)
                .HasForeignKey(e => e.Editora)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Generos>()
                .Property(e => e.Tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Generos>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Generos>()
                .HasMany(e => e.Livros)
                .WithRequired(e => e.Generos)
                .HasForeignKey(e => e.Genero)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Livros>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Livros>()
                .Property(e => e.Isbn)
                .IsUnicode(false);

            modelBuilder.Entity<Livros>()
                .Property(e => e.Observacoes)
                .IsUnicode(false);

            modelBuilder.Entity<Livros>()
                .HasMany(e => e.Locacao)
                .WithRequired(e => e.Livros)
                .HasForeignKey(e => e.Livro)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Senha)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Livros)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.UsuAlt)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Livros1)
                .WithRequired(e => e.Usuario1)
                .HasForeignKey(e => e.UsuInc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Locacao)
                .WithRequired(e => e.Usuario1)
                .HasForeignKey(e => e.UsuAlt)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Locacao1)
                .WithRequired(e => e.Usuario2)
                .HasForeignKey(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Locacao2)
                .WithRequired(e => e.Usuario3)
                .HasForeignKey(e => e.UsuInc)
                .WillCascadeOnDelete(false);
        }
    }
}
